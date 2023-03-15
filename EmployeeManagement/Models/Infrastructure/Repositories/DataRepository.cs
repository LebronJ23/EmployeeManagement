using EmployeeManagement.Models.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public IQueryable<Department> Departments => dataContext.Departments;

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

        public Employee FindEmployeeById(long id)
        {
            return dataContext.Employees.Find(id);
        }

        public async Task<Employee> FindEmployeeByIdAsync(long id)
        {
            return await dataContext.Employees.FindAsync(id);
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
