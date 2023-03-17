using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Utils.Extensions
{
    /// <summary>
    /// Класс методов расширения для ModelBuilder
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Метод расширения заполнения начальными данными базы
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Front-end", City = "Moscow" },
                new Department { Id = 2, Name = "Back-end", City = "Kaliningrad" },
                new Department { Id = 3, Name = "Design", City = "Krasnodar" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "Olegov",
                    Surname = "Vladimirovich",
                    BirthDay = DateTime.MinValue,
                    DepartmentId = 3,
                    Description = "SeedDescription1",
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Alexandr",
                    LastName = "Kibitkov",
                    Surname = "Sergeevich",
                    BirthDay = DateTime.MinValue,
                    DepartmentId = 3,
                    Description = "SeedDescription2",
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Artur",
                    LastName = "Oganezov",
                    Surname = "Mahmetovich",
                    BirthDay = DateTime.MinValue,
                    DepartmentId = 1,
                    Description = "SeedDescription3",
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Vitaliy",
                    LastName = "Serebryanko",
                    Surname = "Alekseevich",
                    BirthDay = DateTime.MinValue,
                    DepartmentId = 1,
                    Description = "SeedDescription4",
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Georgiy",
                    LastName = "Sardanov",
                    Surname = "Konstantinovich",
                    BirthDay = DateTime.MinValue,
                    DepartmentId = 2,
                    Description = "SeedDescription5",
                },
                new Employee
                {
                    Id = 6,
                    FirstName = "Vasiliy",
                    LastName = "Kvartalov",
                    Surname = "Kantemirovich",
                    BirthDay = DateTime.MinValue,
                    DepartmentId = 2,
                    Description = "SeedDescription6",
                },
                new Employee
                {
                    Id = 7,
                    FirstName = "Harry",
                    LastName = "Imperatorov",
                    Surname = "Alexandrovich",
                    BirthDay = DateTime.MinValue,
                    DepartmentId = 2,
                    Description = "SeedDescription7",
                }
            );
        }
    }
}
