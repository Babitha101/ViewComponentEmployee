using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentEmployee.Models;

using MongoDB.Driver;
using MongoDB.Bson;
using System.ComponentModel;

namespace ViewComponentEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        //private List<Employee> _employeeList;

        public EmployeeController()
        {
            //_employeeList = new List<Employee>(){ new Employee { empid=1,empname="John",Department="HR",Email="john@abc.com"},
            //    new Employee { empid = 2, empname = "Arjun", Department = "IT", Email = "arjun@abc.com" },
            //    new Employee { empid = 3, empname = "Kamal", Department = "Payroll", Email = "john@abc.com" },
            //    new Employee { empid = 4, empname = "Divya", Department = "HR", Email = "john@abc.com" },
            //    new Employee { empid = 5, empname = "Neha", Department = "Payroll", Email = "john@abc.com" }};

        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var database = mongoClient.GetDatabase("Employee");
            var collection = database.GetCollection<Employee>("Employees");
            var EmployeeResult = collection.Find<Employee>(a => true).ToList();
            return View(EmployeeResult);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                    var database = mongoClient.GetDatabase("Employee");

                    var collection = database.GetCollection<Employee>("Employees");

                    // var EmployeeResult = collection.Find(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id))).SingleOrDefault();

                    collection.InsertOne(employee);
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

            return ViewComponent("Edit",id);

            //var database = mongoClient.GetDatabase("Employee");
            //var collection = database.GetCollection<Employee>("Employees");

            //var EmployeeResult = collection.Find(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id))).SingleOrDefault();
            //return View("Edit", EmployeeResult);

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
                    var database = mongoClient.GetDatabase("Employee");

                    var collection = database.GetCollection<Employee>("Employees");

                    var update = collection.FindOneAndUpdateAsync(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id)), Builders<Employee>.Update.Set("empname",employee.empname).Set("Department", employee.Department).Set("Email", employee.Email));
                    //return RedirectToAction("About");

                    return View("Default");
                    //return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

//var empList= _employeeList.Where(x => x.empid == id)
//     .Select(g => new Employee()
//     {
//         empid = g.empid,
//         empname = g.empname,
//         Email = g.Email,
//         Department = g.Department

//     }).ToList();

//return View(empList);
//return View();
