using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Модель сотрудника
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Surname { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Идентификатор отдела сотрудника
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// Отдел сотрудника
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// О себе
        /// </summary>
        public string Description { get; set; }
    }
}
