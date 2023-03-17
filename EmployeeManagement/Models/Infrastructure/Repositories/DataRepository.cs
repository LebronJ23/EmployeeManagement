using EmployeeManagement.Models.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Infrastructure.Repositories
{
    /// <summary>
    /// Репозиторий данный
    /// </summary>
    public class DataRepository : IDataRepository
    {
        // Контекст
        private DataContext dataContext;

        public DataRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        // Сотрудники
        public IQueryable<Employee> Employees => dataContext.Employees.Include(e => e.Department);

        // Отделы
        public IQueryable<Department> Departments => dataContext.Departments.Include(d => d.Employees);

        /// <summary>
        /// Метод создания отдела
        /// Синхронная версия
        /// </summary>
        /// <param name="d">Отдел</param>
        public void CreateDepartment(Department d)
        {
            dataContext.Add(d);
            dataContext.SaveChanges();
        }

        /// <summary>
        /// Метод создания отдела
        /// Асинхронная версия
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public async Task CreateDepartmentAsync(Department d)
        {
            dataContext.Add(d);
            await dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод создания сотрудника
        /// Синхронная версия
        /// </summary>
        /// <param name="e">Сотрудник</param>
        public void CreateEmployee(Employee e)
        {
            dataContext.Add(e);
            dataContext.SaveChanges();
        }

        /// <summary>
        /// Метод создания сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="e">Сотрудник</param>
        /// <returns></returns>
        public async Task CreateEmployeeAsync(Employee e)
        {
            dataContext.Add(e);
            await dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод удаления отдела
        /// Синхронная версия
        /// </summary>
        /// <param name="d">Отдел</param>
        public void DeleteDepartment(Department d)
        {
            dataContext.Remove(d);
            dataContext.SaveChanges();
        }

        /// <summary>
        /// Метод удаления отдела
        /// Асинхронная версия
        /// </summary>
        /// <param name="d">Отдел</param>
        public async Task DeleteDepartmentAsync(Department d)
        {
            dataContext.Remove(d);
            await dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод удаления сотрудника
        /// Синхронная версия
        /// </summary>
        /// <param name="e">Сотрудник</param>
        public void DeleteEmployee(Employee e)
        {
            dataContext.Remove(e);
            dataContext.SaveChanges();
        }

        /// <summary>
        /// Метод удаления сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="e">Сотрудник</param>
        public async Task DeleteEmployeeAsync(Employee e)
        {
            dataContext.Remove(e);
            await dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод поиска отдела по индетификатору
        /// Синхронная версия
        /// </summary>
        /// <param name="id">Отдел</param>
        /// <returns></returns>
        public Department FindDepartmentById(long id)
        {
            return dataContext.Departments.Find(id);
        }

        /// <summary>
        /// Метод поиска отдела по индетификатору
        /// Асинхронная версия
        /// </summary>
        /// <param name="id">Отдел</param>
        /// <returns></returns>
        public async Task<Department> FindDepartmentByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await dataContext.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }

        /// <summary>
        /// Метод поиска сотрудника по индетификатору
        /// Синхронная версия
        /// </summary>
        /// <param name="id">Сотрудник</param>
        /// <returns></returns>
        public Employee FindEmployeeById(long id)
        {
            return dataContext.Employees.Find(id);
        }

        /// <summary>
        /// Метод поиска сотрудника по индетификатору
        /// Асинхронная версия
        /// </summary>
        /// <param name="id">Сотрудник</param>
        /// <returns></returns>
        public async Task<Employee> FindEmployeeByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await dataContext.Employees.FindAsync(new object[] { id }, cancellationToken);
        }

        /// <summary>
        /// Метод обновления отдела
        /// Синхронная версия
        /// </summary>
        /// <param name="d">Отдел</param>
        public void SaveDepartment(Department d)
        {
            dataContext.Update(d);
            dataContext.SaveChanges();
        }

        /// <summary>
        /// Метод обновления отдела
        /// Асинхронная версия
        /// </summary>
        /// <param name="d">Отдел</param>
        public async Task SaveDepartmentAsync(Department d)
        {
            dataContext.Update(d);
            await dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод обновления сотрудника
        /// Синхронная версия
        /// </summary>
        /// <param name="d">Сотрудник</param>
        public void SaveEmployee(Employee e)
        {
            dataContext.Update(e);
            dataContext.SaveChanges();
        }

        /// <summary>
        /// Метод обновления сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="d">Сотрудник</param>
        public async Task SaveEmployeeAsync(Employee e)
        {
            dataContext.Update(e);
            await dataContext.SaveChangesAsync();
        }
    }
}
