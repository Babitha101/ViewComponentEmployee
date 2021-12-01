using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentEmployee.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ViewComponentEmployee.ViewComponentEmp
{
    public class EmployeeDetailsViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeDetailsViewComponent(IEmployeeRepository employeeRespository)
        {
            _employeeRepository = employeeRespository;
        }
        public IViewComponentResult Invoke()
        {

            var EmployeeResult = _employeeRepository.GetEmployees();
            return View(EmployeeResult);
        }

    }

}
