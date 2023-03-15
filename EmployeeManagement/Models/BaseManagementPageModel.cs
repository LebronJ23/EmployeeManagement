using EmployeeManagement.Models.Infrastructure.Interfaces;
using EmployeeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class BaseManagementPageModel : PageModel
    {
        public IDataRepository Repository { get; set; }
        public BaseManagementPageModel(IDataRepository repo)
        {
            Repository = repo;
        }

        public IEnumerable<Department> Departments => Repository.Departments;

        public EmployeeViewModel ViewModel { get; set; }
    }
}
