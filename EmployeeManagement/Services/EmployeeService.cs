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
    /// <summary>
    /// Сервия по работе с сотрудниками
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private IDataRepository Repository { get; }

        public EmployeeService(IDataRepository repository)
        {
            Repository = repository;
        }

        /// <inheritdoc />
        public IEnumerable<Employee> GetEmployees => Repository.Employees;

        /// <inheritdoc />
        public async Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            employee.Id = default;
            employee.Department = default;

            await Repository.CreateEmployeeAsync(employee);
        }

        /// <inheritdoc />
        public async Task DeleteEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            await Repository.DeleteEmployeeAsync(employee);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Employee>> GetEmployeeListAsync(CancellationToken cancellationToken)
        {
            return await Repository.Employees.ToListAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Employee> GetEmployeeAsync(long id, CancellationToken cancellationToken)
        {
            return await Repository.FindEmployeeByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc />
        public async Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            employee.Department = default;

            await Repository.SaveEmployeeAsync(employee);
        }

        /// <inheritdoc />
        public async Task SetDepartmentAsync(long employeeId, long departmnetId)
        {
            var employee = await Repository.FindEmployeeByIdAsync(employeeId);
            employee.DepartmentId = departmnetId;
            await Repository.SaveEmployeeAsync(employee);
        }
    }
}
