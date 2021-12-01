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
    public class EditViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EditViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IViewComponentResult Invoke(string id)   
        {
            var EmployeeResult = _employeeRepository.GetEmployee(id);
            return View("Default", EmployeeResult);          
        }
    }
}
