using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentEmployee.Models;

namespace ViewComponentEmployee.ViewComponentEmp
{
    public class HeadCountViewComponent:ViewComponent
    {
        private readonly IEmployeeRepository employeeRepository;
        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public IViewComponentResult Invoke()
        {
           var resultCount= employeeRepository.EmployeeCountByDept();
            return View(resultCount);
        }

      

    }
}
