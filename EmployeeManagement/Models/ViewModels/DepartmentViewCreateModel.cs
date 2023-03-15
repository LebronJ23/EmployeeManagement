using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Models.ViewModels
{
    public class DepartmentViewCreateModel
    {
        [BindProperty]
        public Department Department { get; set; }

        public string ReturnAction { get; set; }
        public string ReturnController { get; set; }
        public string EmployeeId { get; set; }
    }
}
