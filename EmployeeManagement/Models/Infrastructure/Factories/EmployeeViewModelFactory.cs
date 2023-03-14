using EmployeeManagement.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models.Infrastructure.Factories
{
    public static class EmployeeViewModelFactory
    {
        public static EmployeeViewModel Create(Employee e, IEnumerable<Department> departments)
        {
            return new EmployeeViewModel
            {
                Employee = e,
                Departments = departments
            };
        }

        public static EmployeeViewModel Details(Employee e)
        {
            return new EmployeeViewModel 
            { 
                Employee = e,
                Departments = e == null ? Enumerable.Empty<Department>() : new List<Department> { e.Department },
                Action = "Details",
                Theme = "info",
                ReadOnly = true,
                ShowAction = false
            };
        }

        public static EmployeeViewModel Edit(Employee e, IEnumerable<Department> departments)
        {
            return new EmployeeViewModel
            {
                Employee = e,
                Departments = departments,
                Action = "Edit",
                Theme = "warning",
            };
        }

        public static EmployeeViewModel Delete(Employee e, IEnumerable<Department> departments)
        {
            return new EmployeeViewModel
            {
                Employee = e,
                Departments = departments,
                Action = "Delete",
                Theme = "danger",
                ReadOnly = true
            };
        }
    }
}
