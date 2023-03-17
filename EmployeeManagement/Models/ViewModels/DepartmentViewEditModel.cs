using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models.ViewModels
{
    /// <summary>
    /// Модель представления редактирования отдела (добавление сотрудников)
    /// </summary>
    public class DepartmentViewEditModel
    {
        /// <summary>
        /// Отдел
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public IEnumerable<Employee> Employees;

        /// <summary>
        /// Сотрудники относящиеся к отедлу
        /// </summary>
        public IEnumerable<Employee> Staff => Department.Employees;

        /// <summary>
        /// Сотрудники НЕ относящиеся к отедлу
        /// </summary>
        public IEnumerable<Employee> NotStaff => Employees.Except(Staff);
    }
}
