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

        public IEnumerable<Employee> GetEmployees()//Get All Employees
        {
            var EmployeeResult = _employee.Find<Employee>(a => true).ToList();
            return EmployeeResult;

        }
        public IEnumerable<Employee> GetEmployee(string id)//Get Employee By ID
        {
            var EmployeeResult = _employee.Find(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id))).ToList();
            return EmployeeResult;
            //var EmployeeResult = collection.Find(Builders<Employee>.Filter.Eq("id", ObjectId.Parse(id))).SingleOrDefault();
        }
        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }
        public Employee Update(Employee updatedemployee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
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

        //HeadCountModel IEmployeeRepository.Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public HeadCountModel Add(HeadCountModel employee)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Employee> GetEmployee(int id)
        //{
        //    id = 1;
        //    //Employee empModel = new Employee();


        //    return _employeeList.Where(x => x.empid == id)
        //         .Select(g => new Employee()
        //         {
        //             empid = g.empid,
        //             empname = g.empname,
        //             Email = g.Email,
        //             Department = g.Department

        //         }).ToList();

        //    //return resultList;

        //}


    }
}
