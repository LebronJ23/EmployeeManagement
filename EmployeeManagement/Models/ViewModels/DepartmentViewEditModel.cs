using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models.ViewModels
{
    public class DepartmentViewEditModel
    {
        public Department Department { get; set; }
        public IEnumerable<Employee> Employees;
        public IEnumerable<Employee> Staff => Department.Employees;
        public IEnumerable<Employee> NotStaff => Employees.Except(Staff);
    }
}
