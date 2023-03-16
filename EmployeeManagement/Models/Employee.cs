using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public long Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Index("IX_Initials", Order = 1, IsUnique = true)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Index("IX_Initials", Order = 2, IsUnique = true)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Index("IX_Initials", Order = 3, IsUnique = true)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Description { get; set; }
    }
}
