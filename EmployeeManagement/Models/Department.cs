using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Модель отдела
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        /// <summary>
        /// Город расположения отдела
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string City { get; set; }

        /// <summary>
        /// Список сотрудников отдела
        /// </summary>
        public IEnumerable<Employee> Employees { get; set; }
    }
}
