using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.Models.Infrastructure.Interfaces.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees { get; }
        ConfiguredCancelableAsyncEnumerable<Employee> GetEmployeeListAsync(CancellationToken cancellationToken);
        Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
        Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
        Task DeleteEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> GetEmployeeAsync(long id, CancellationToken cancellationToken);
        Task SetDepartmentAsync(long employeeId, long departmnetId);
    }
}
