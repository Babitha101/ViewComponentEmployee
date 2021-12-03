using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentEmployee.Models;
using Microsoft.AspNetCore.Http;


using MongoDB.Driver;
using MongoDB.Bson;
using System.ComponentModel;
namespace ViewComponentEmployee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        //private List<Employee> _employeeList;

        public HomeController()
        {
            
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

            return ViewComponent("Edit", id);

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

                    var update = collection.FindOneAndUpdateAsync(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id)), Builders<Employee>.Update.Set("Name", employee.Name).Set("Department", employee.Department).Set("Email", employee.Email));
                  
                    return ViewComponent("EmployeeDetails");

                    //return View("Components/EmployeeDetails/Default");
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
