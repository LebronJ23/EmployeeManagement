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

        /// <summary>
        /// Все сотрудники
        /// </summary>
        public IEnumerable<Employee> GetEmployees => Repository.Employees;

        /// <summary>
        /// Добавление сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            employee.Id = default;
            employee.Department = default;

            await Repository.CreateEmployeeAsync(employee);
        }

        /// <summary>
        /// Удаление сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            await Repository.DeleteEmployeeAsync(employee);
        }

        /// <summary>
        /// Получение списка сотрудников
        /// Асинхронная версия
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ConfiguredCancelableAsyncEnumerable<Employee> GetEmployeeListAsync(CancellationToken cancellationToken)
        {
            return Repository.Employees.AsAsyncEnumerable().WithCancellation(cancellationToken);
        }

        /// <summary>
        /// Получение сотрудника по идентификатору
        /// Асинхронная версия
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeAsync(long id, CancellationToken cancellationToken)
        {
            return await Repository.FindEmployeeByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновление сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            employee.Department = default;

            await Repository.SaveEmployeeAsync(employee);
        }

        /// <summary>
        /// Установка нового отдела для сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="departmnetId">Идентификатор отдела</param>
        /// <returns></returns>
        public async Task SetDepartmentAsync(long employeeId, long departmnetId)
        {
            var employee = await Repository.FindEmployeeByIdAsync(employeeId);
            employee.DepartmentId = departmnetId;
            await Repository.SaveEmployeeAsync(employee);
        }
    }
}
