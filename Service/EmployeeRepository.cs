using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ViewComponentEmployee.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<HeadCountModel> _employeeList;
        private readonly IMongoCollection<Employee> _employee;

        public EmployeeRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Employee");
            var collection = database.GetCollection<Employee>("Employees");
            _employee = collection;
        }
        public IEnumerable<Employee> GetEmployees()        //Get All Employees
        {
            var employeeResult = _employee.AsQueryable<Employee>().ToList();
            return employeeResult;
        }
        public Employee GetEmployee(string id)      //Get Employee By ID
        {
            var employeeResult = _employee.Find(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id))).FirstOrDefault();
            return employeeResult;
        }
        public void Add(Employee employee)//Insert Employee
        {
            _employee.InsertOne(employee);
        }
        public void Update(Employee employee, string id)         //Update Employee
        {
             _employee.FindOneAndUpdateAsync(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id)), Builders<Employee>.Update.Set("Name", employee.Name).Set("Department", employee.Department).Set("Email", employee.Email));
        }

        public void Delete(string id)          //Delete Employee
        {
            _employee.DeleteOneAsync(a => a.id == id);
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept()
        {
            return _employeeList.GroupBy(e => e.Department)
                .Select(g => new DeptHeadCount()
                {
                    Department = g.Key,
                    Count = g.Count()
                }).ToList();
        }

    }
}
