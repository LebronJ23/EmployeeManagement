using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models.ViewModels
{
    /// <summary>
    /// Модель представления
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Отделы
        /// </summary>
        public IEnumerable<Department> Departments { get; set; } = Enumerable.Empty<Department>();

        /// <summary>
        /// Метод действия
        /// </summary>
        public string Action { get; set; } = "Create";

        /// <summary>
        /// Цветовая тема
        /// </summary>
        public string Theme { get; set; } = "primary";

        /// <summary>
        /// Доступ на редактирование полей
        /// </summary>
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Доступ к кнопке действия
        /// </summary>
        public bool ShowAction { get; set; } = true;
    }
}
