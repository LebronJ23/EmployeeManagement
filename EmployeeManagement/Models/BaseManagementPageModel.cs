using EmployeeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class BaseManagementPageModel : PageModel
    {
        public DataContext Context { get; set; }
        public BaseManagementPageModel(DataContext dataContext)
        {
            Context = dataContext;
        }

        public IEnumerable<Department> Departments => Context.Departments;

        public EmployeeViewModel ViewModel { get; set; }
    }
}
