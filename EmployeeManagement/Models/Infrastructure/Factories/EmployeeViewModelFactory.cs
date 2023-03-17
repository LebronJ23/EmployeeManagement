using EmployeeManagement.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models.Infrastructure.Factories
{
    /// <summary>
    /// Фабрика по созданию моделей представления для сотрудников
    /// </summary>
    public static class EmployeeViewModelFactory
    {
        /// <summary>
        /// Модель представления создания сотрудника
        /// </summary>
        /// <param name="e">Сотрудник</param>
        /// <param name="departments">Список отделов</param>
        /// <returns></returns>
        public static EmployeeViewModel Create(Employee e, IEnumerable<Department> departments)
        {
            return new EmployeeViewModel
            {
                Employee = e,
                Departments = departments
            };
        }

        /// <summary>
        /// Модель представления детальной информации по сотруднику
        /// </summary>
        /// <param name="e">Сотрудник</param>
        /// <returns></returns>
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

        /// <summary>
        /// Модель представления редактирования сотрудника
        /// </summary>
        /// <param name="e">Сотрудник</param>
        /// <param name="departments">Список отделов</param>
        /// <returns></returns>
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

        /// <summary>
        /// Модель представления удаления сотрудника
        /// </summary>
        /// <param name="e">Сотрудник</param>
        /// <param name="departments">Список отделов</param>
        /// <returns></returns>
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
