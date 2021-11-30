﻿using Microsoft.AspNetCore.Mvc;
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
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        //public EditViewComponent(IEmployeeRepository employeeRepository)
        //{
        //    this.employeeRepository = employeeRepository;
        //}

        public IViewComponentResult Invoke(string id)   
        {
            var database = mongoClient.GetDatabase("Employee");
            var collection = database.GetCollection<Employee>("Employees");

            var EmployeeResult = collection.Find(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id))).SingleOrDefault();
            return View("Default", EmployeeResult);
          
        }
    }
}
