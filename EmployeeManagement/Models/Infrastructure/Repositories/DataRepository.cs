using EmployeeManagement.Models.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Infrastructure.Repositories
{
    public class DataRepository : IDataRepository
    {
        private DataContext dataContext;

        public DataRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        public IQueryable<Employee> Employees => dataContext.Employees.Include(e => e.Department);

        public IQueryable<Department> Departments => dataContext.Departments.Include(d => d.Employees);

        public void CreateDepartment(Department d)
        {
            dataContext.Add(d);
            dataContext.SaveChanges();
        }

        public async Task CreateDepartmentAsync(Department d)
        {
            dataContext.Add(d);
            await dataContext.SaveChangesAsync();
        }

        public void CreateEmployee(Employee e)
        {
            dataContext.Add(e);
            dataContext.SaveChanges();
        }

        public async Task CreateEmployeeAsync(Employee e)
        {
            dataContext.Add(e);
            await dataContext.SaveChangesAsync();
        }

        public void DeleteDepartment(Department d)
        {
            dataContext.Remove(d);
            dataContext.SaveChanges();
        }

        public async Task DeleteDepartmentAsync(Department d)
        {
            dataContext.Remove(d);
            await dataContext.SaveChangesAsync();
        }

        public void DeleteEmployee(Employee e)
        {
            dataContext.Remove(e);
            dataContext.SaveChanges();
        }

        public async Task DeleteEmployeeAsync(Employee e)
        {
            dataContext.Remove(e);
            await dataContext.SaveChangesAsync();
        }

        public Department FindDepartmentById(long id)
        {
            return dataContext.Departments.Find(id);
        }

        public async Task<Department> FindDepartmentByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await dataContext.Departments.FindAsync(id, cancellationToken);
        }

        public Employee FindEmployeeById(long id)
        {
            return dataContext.Employees.Find(id);
        }

        public async Task<Employee> FindEmployeeByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await dataContext.Employees.FindAsync(id, cancellationToken);
        }

        public void SaveDepartment(Department d)
        {
            dataContext.Update(d);
            dataContext.SaveChanges();
        }

        public async Task SaveDepartmentAsync(Department d)
        {
            dataContext.Update(d);
            await dataContext.SaveChangesAsync();
        }

        public void SaveEmployee(Employee e)
        {
            dataContext.Update(e);
            dataContext.SaveChanges();
        }

        public async Task SaveEmployeeAsync(Employee e)
        {
            dataContext.Update(e);
            await dataContext.SaveChangesAsync();
        }
    }
}
