using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Models.ViewModels
{
    /// <summary>
    /// Модель представления создания департамента
    /// </summary>
    public class DepartmentViewCreateModel
    {
        /// <summary>
        /// Отдел
        /// </summary>
        [BindProperty]
        public Department Department { get; set; }

        /// <summary>
        /// Метод действия возврата
        /// </summary>
        public string ReturnAction { get; set; }

        /// <summary>
        /// Контроллер действия возврата
        /// </summary>
        public string ReturnController { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public string EmployeeId { get; set; }
    }
}
