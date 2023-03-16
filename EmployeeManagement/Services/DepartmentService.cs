using EmployeeManagement.Models;
using EmployeeManagement.Models.Infrastructure.Interfaces;
using EmployeeManagement.Models.Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDataRepository Repository { get; }

        public DepartmentService(IDataRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Department> GetDepartments => Repository.Departments;

        public async Task AddDepartmentAsync(Department department, CancellationToken cancellationToken = default)
        {
            await Repository.CreateDepartmentAsync(department);
        }

        public async Task DeleteDepartmentAsync(Department department, CancellationToken cancellationToken = default)
        {
            await Repository.DeleteDepartmentAsync(department);
        }

        public async Task<Department> GetDepartmentAsync(long id, CancellationToken cancellationToken)
        {
            return await Repository.FindDepartmentByIdAsync(id, cancellationToken);
        }

        public ConfiguredCancelableAsyncEnumerable<Department> GetDepartmentsListAsync(CancellationToken cancellationToken)
        {
            return Repository.Departments.AsAsyncEnumerable().WithCancellation(cancellationToken);
        }

        public async Task UpdateDepartmentAsync(Department department, CancellationToken cancellationToken = default)
        {
            await Repository.SaveDepartmentAsync(department);
        }

        public async Task DeleteDepartmentAsync(long id, CancellationToken cancellationToken = default)
        {
            var department = await Repository.FindDepartmentByIdAsync(id);
            await Repository.DeleteDepartmentAsync(department);
        }
    }
}
