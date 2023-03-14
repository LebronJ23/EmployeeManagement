using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
