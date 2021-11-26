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
        public IViewComponentResult Invoke(Employee employee)
        {
            return View(employee);
        }
    }



}
