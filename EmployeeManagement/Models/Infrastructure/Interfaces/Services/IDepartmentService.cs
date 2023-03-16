using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace EmployeeManagement.Models.Infrastructure.Interfaces.Services
{
    public interface IDepartmentService
    {
        ConfiguredCancelableAsyncEnumerable<Department> GetDepartmentsListAsync(CancellationToken cancellationToken);
        IEnumerable<Department> GetDepartments { get; }
        Task AddDepartmentAsync(Department department, CancellationToken cancellationToken = default);
        Task UpdateDepartmentAsync(Department department, CancellationToken cancellationToken = default);
        Task DeleteDepartmentAsync(Department department, CancellationToken cancellationToken = default);
        Task DeleteDepartmentAsync(long id, CancellationToken cancellationToken = default);
        Task<Department> GetDepartmentAsync(long id, CancellationToken cancellationToken);
    }
}
