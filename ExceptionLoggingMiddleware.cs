
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ILogger = Serilog.ILogger;

namespace ViewComponentEmployee
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        const string MessageTemplate =
            "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        static readonly ILogger Log = Serilog.Log.ForContext<ExceptionLoggingMiddleware>();


        public ExceptionLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //context.Request.EnableBuffering();
            if (context == null) throw new ArgumentNullException(nameof(context));

            var sw = Stopwatch.StartNew();

            try
            {
                await _next(context);
                sw.Stop();
                var statusCode = context.Response?.StatusCode;
                var level = statusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;

                var log = level == LogEventLevel.Error ? LogForErrorContext(context) : Log;

                log.Write(level, MessageTemplate, context.Request.Method, context.Request.Path, statusCode, sw.Elapsed.TotalMilliseconds);
            }
            catch (Exception ex) when (LogException(context, sw, ex)) { }
        }
        static bool LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
        {
            sw.Stop();

            LogForErrorContext(httpContext)
                .Error(ex, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, 500, sw.Elapsed.TotalMilliseconds);

            return false;
        }
        static ILogger LogForErrorContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            var result = Log
                .ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
                .ForContext("RequestHost", request.Host)
                .ForContext("RequestProtocol", request.Protocol);

            if (request.HasFormContentType)
                result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));

            return result;
        }
      
    }

}




