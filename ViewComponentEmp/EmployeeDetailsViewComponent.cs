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
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
        public IViewComponentResult Invoke()
        {
            var database = mongoClient.GetDatabase("Employee");
            var collection = database.GetCollection<Employee>("Employees");
            var EmployeeResult = collection.Find<Employee>(a => true).ToList();
            return View(EmployeeResult);
        }

    }

}
