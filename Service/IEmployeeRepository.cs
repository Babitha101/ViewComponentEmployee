using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentEmployee.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(string id);
        void Update(Employee updatedemployee,string id);
        void Add(Employee employee);
        void Delete(string id);
        IEnumerable<DeptHeadCount> EmployeeCountByDept();
    }
}
