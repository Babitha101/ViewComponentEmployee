using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentEmployee.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Logging;

namespace ViewComponentEmployee.ViewComponentEmp
{
    public class EmployeeDetailsViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;
        public EmployeeDetailsViewComponent(IEmployeeRepository employeeRespository,ILogger<EmployeeDetailsViewComponent> logger)
        {
            _employeeRepository = employeeRespository;
            _logger = logger;
        }
        public IViewComponentResult Invoke()
        {
            _logger.LogInformation("Log message in the EmployeeDetailsViewComponent method");
            //throw new System.Exception("An error occurred");
            var EmployeeResult = _employeeRepository.GetEmployees();
            return View(EmployeeResult);
        }

    }

}
