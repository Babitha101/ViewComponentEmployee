using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentEmployee.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>(){ new Employee { empid=1,empname="John",Department="HR",Email="john@abc.com"},
                new Employee { empid = 2, empname = "Arjun", Department = "IT", Email = "arjun@abc.com" },
                new Employee { empid = 3, empname = "Kamal", Department = "Payroll", Email = "john@abc.com" },
                new Employee { empid = 4, empname = "Divya", Department = "HR", Email = "john@abc.com" },
                new Employee { empid = 5, empname = "Neha", Department = "Payroll", Email = "john@abc.com" }};

        }
        public Employee Add(Employee employee)
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

        public IEnumerable<Employee> GetEmployee(int id)
        {
            Employee empModel = new Employee();


            var resultList = _employeeList.Where(x => x.empid == id);

            return resultList;
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee updatedemployee)
        {
            throw new NotImplementedException();
        }
    }
}
