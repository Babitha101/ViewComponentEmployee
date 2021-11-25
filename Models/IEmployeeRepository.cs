using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentEmployee.Models
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee updatedemployee);
        Employee Add(Employee employee);
        Employee Delete(int id);

        IEnumerable<DeptHeadCount> EmployeeCountByDept();
    }
}
