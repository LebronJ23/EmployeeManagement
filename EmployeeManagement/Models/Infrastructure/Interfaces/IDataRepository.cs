using System.Linq;
using System.Threading;
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

        void CreateDepartment(Department d);
        void SaveDepartment(Department d);
        void DeleteDepartment(Department d);
        Department FindDepartmentById(long id);

        Task CreateEmployeeAsync(Employee e);
        Task SaveEmployeeAsync(Employee e);
        Task DeleteEmployeeAsync(Employee e);
        Task<Employee> FindEmployeeByIdAsync(long id, CancellationToken cancellationToken = default);

        Task CreateDepartmentAsync(Department d);
        Task SaveDepartmentAsync(Department d);
        Task DeleteDepartmentAsync(Department d);
        Task<Department> FindDepartmentByIdAsync(long id, CancellationToken cancellationToken = default);

    }
}
