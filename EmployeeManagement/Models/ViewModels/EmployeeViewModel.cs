using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Department> Departments { get; set; } = Enumerable.Empty<Department>();

        public string Action { get; set; } = "Create";
        public string Theme { get; set; } = "primary";
        public bool ReadOnly { get; set; } = false;
        public bool ShowAction { get; set; } = true;
    }
}
