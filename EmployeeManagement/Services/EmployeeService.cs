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
    public class EmployeeService : IEmployeeService
    {
        private IDataRepository Repository { get; }

        public EmployeeService(IDataRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Employee> GetEmployees => Repository.Employees;

        public async Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            employee.Id = default;
            employee.Department = default;

            await Repository.CreateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            await Repository.DeleteEmployeeAsync(employee);
        }

        public ConfiguredCancelableAsyncEnumerable<Employee> GetEmployeeListAsync(CancellationToken cancellationToken)
        {
            return Repository.Employees.AsAsyncEnumerable().WithCancellation(cancellationToken);
        }

        public async Task<Employee> GetEmployeeAsync(long id, CancellationToken cancellationToken)
        {
            return await Repository.FindEmployeeByIdAsync(id, cancellationToken);
        }

        public async Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            employee.Department = default;

            await Repository.SaveEmployeeAsync(employee);
        }

        public async Task SetDepartmentAsync(long employeeId, long departmnetId)
        {
            var employee = await Repository.FindEmployeeByIdAsync(employeeId);
            employee.DepartmentId = departmnetId;
            await Repository.SaveEmployeeAsync(employee);
        }
    }
}
