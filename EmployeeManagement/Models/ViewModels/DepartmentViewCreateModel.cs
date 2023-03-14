using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Models.ViewModels
{
    public class DepartmentViewCreateModel
    {
        [BindProperty]
        public Department Department { get; set; }

        public string ReturnPage { get; set; }
        public string EmployeeId { get; set; }
    }
}
