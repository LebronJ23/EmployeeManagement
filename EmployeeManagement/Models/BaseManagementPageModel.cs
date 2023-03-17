using EmployeeManagement.Models.Infrastructure.Interfaces;
using EmployeeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Базовый класс для страниц управления сотрудниками
    /// </summary>
    public class BaseManagementPageModel : PageModel
    {
        public IDataRepository Repository { get; set; }
        public BaseManagementPageModel(IDataRepository repo)
        {
            Repository = repo;
        }

        /// <summary>
        /// Отделы
        /// </summary>
        public IEnumerable<Department> Departments => Repository.Departments;

        /// <summary>
        /// Модель страницы
        /// </summary>
        public EmployeeViewModel ViewModel { get; set; }
    }
}
