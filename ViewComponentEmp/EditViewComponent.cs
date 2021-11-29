using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentEmployee.Models;

namespace ViewComponentEmployee.ViewComponentEmp
{
    public class EditViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository employeeRepository;
        public EditViewComponent(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public IViewComponentResult Invoke(int id)
        {
            //var employeeList = employeeRepository.GetEmployee(id);
            //return View(employeeList);
            return View();
        }
    }
}
