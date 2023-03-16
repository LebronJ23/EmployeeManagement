using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmployeeManagement.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if (!(context.Employees.Any() || context.Departments.Any()))
            {

                Department d1 = new Department { Name = "Front-end", City = "Moscow" };
                Department d2 = new Department { Name = "Back-end", City = "Kaliningrad" };
                Department d3 = new Department { Name = "Design", City = "Krasnodar" };

                context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "Ivan",
                        LastName = "Olegov",
                        Surname = "Vladimirovich",
                        BirthDay = DateTime.MinValue,
                        Department = d3,
                        Description = "SeedDescription1",
                    },
                    new Employee
                    {
                        FirstName = "Alexandr",
                        LastName = "Kibitkov",
                        Surname = "Sergeevich",
                        BirthDay = DateTime.MinValue,
                        Department = d3,
                        Description = "SeedDescription2",
                    },
                    new Employee
                    {
                        FirstName = "Artur",
                        LastName = "Oganezov",
                        Surname = "Mahmetovich",
                        BirthDay = DateTime.MinValue,
                        Department = d1,
                        Description = "SeedDescription3",
                    },
                    new Employee
                    {
                        FirstName = "Vitaliy",
                        LastName = "Serebryanko",
                        Surname = "Alekseevich",
                        BirthDay = DateTime.MinValue,
                        Department = d1,
                        Description = "SeedDescription4",
                    },
                    new Employee
                    {
                        FirstName = "Georgiy",
                        LastName = "Sardanov",
                        Surname = "Konstantinovich",
                        BirthDay = DateTime.MinValue,
                        Department = d2,
                        Description = "SeedDescription5",
                    },
                    new Employee
                    {
                        FirstName = "Vasiliy",
                        LastName = "Kvartalov",
                        Surname = "Kantemirovich",
                        BirthDay = DateTime.MinValue,
                        Department = d2,
                        Description = "SeedDescription6",
                    },
                    new Employee
                    {
                        FirstName = "Harry",
                        LastName = "Imperatorov",
                        Surname = "Alexandrovich",
                        BirthDay = DateTime.MinValue,
                        Department = d2,
                        Description = "SeedDescription7",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
