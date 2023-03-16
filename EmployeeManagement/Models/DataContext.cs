using EmployeeManagement.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}
