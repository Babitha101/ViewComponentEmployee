using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentEmployee.Models;


namespace ViewComponentEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public ActionResult Index()
        {
            var EmployeeResult = _employeeRepository.GetEmployees();
            return View(EmployeeResult);
        }
        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            Employee empModel = new Employee();
            return View("Create", empModel);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeRepository.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
            return View();
        }

        // GET: EmployeeController/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            return ViewComponent("Edit", id);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeRepository.Update(employee, id);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
            return View();
        }

        // GET: EmployeeController/Delete/5
      
        public ActionResult Delete(string id)
        {
            _employeeRepository.Delete( id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
