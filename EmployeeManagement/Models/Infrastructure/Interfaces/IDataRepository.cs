using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Infrastructure.Interfaces
{
    public interface IDataRepository
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Department> Departments { get; }

        void CreateEmployee(Employee e);
        void SaveEmployee(Employee e);
        void DeleteEmployee(Employee e);
        Employee FindEmployeeById(long id);

        Task CreateEmployeeAsync(Employee e);
        Task SaveEmployeeAsync(Employee e);
        Task DeleteEmployeeAsync(Employee e);
        Task<Employee> FindEmployeeByIdAsync(long id);

    }
}
