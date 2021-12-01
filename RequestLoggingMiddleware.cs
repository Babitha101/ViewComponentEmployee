
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentEmployee
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();
            try
            {
                await _next(context);
            }
            finally
            {
                //_logger.LogInformation("Log message in the Index() method");

                _logger.LogInformation(
                    // "Request {method} {url} => {statusCode}",
                    "Request {Employee} {https://localhost:44333/} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);  

                //_logger.LogInformation($"Http Request Information:{Environment.NewLine}" +
                //          $"Schema:{context.Request.Scheme} " +
                //          $"Host: {context.Request.Host} " +
                //          $"Path: {context.Request.Path} " +
                //          $"QueryString: {context.Request.QueryString} ");


                // $"Request Body: {ReadStreamInChunks(requestStream)}");

            }
        }
    
    }

}




