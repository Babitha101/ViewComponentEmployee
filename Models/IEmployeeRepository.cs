using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentEmployee.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<HeadCountModel> GetEmployees();
        //Employee GetEmployee(int id);

        //IEnumerable<Employee> GetEmployee(int id);

        HeadCountModel Update(HeadCountModel updatedemployee);
        HeadCountModel Add(HeadCountModel employee);
        HeadCountModel Delete(int id);

        IEnumerable<DeptHeadCount> EmployeeCountByDept();
    }
}
