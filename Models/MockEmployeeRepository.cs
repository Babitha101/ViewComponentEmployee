using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentEmployee.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<HeadCountModel> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<HeadCountModel>(){ new HeadCountModel { id=1,empname="John",Department="HR",Email="john@abc.com"},
                new HeadCountModel { id = 2, empname = "Arjun", Department = "IT", Email = "arjun@abc.com" },
                new HeadCountModel { id = 3, empname = "Kamal", Department = "Payroll", Email = "john@abc.com" },
                new HeadCountModel { id = 4, empname = "Divya", Department = "HR", Email = "john@abc.com" },
                new HeadCountModel { id = 5, empname = "Neha", Department = "Payroll", Email = "john@abc.com" }};

        }
        public HeadCountModel Add(HeadCountModel employee)
        {
            throw new NotImplementedException();
        }

        public HeadCountModel Delete(int id)
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

        public IEnumerable<HeadCountModel> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public HeadCountModel Update(HeadCountModel updatedemployee)
        {
            throw new NotImplementedException();
        }
    }
}
