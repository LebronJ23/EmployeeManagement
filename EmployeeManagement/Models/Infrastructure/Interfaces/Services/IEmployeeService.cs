using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.Models.Infrastructure.Interfaces.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Все сотрудники
        /// </summary>
        IEnumerable<Employee> GetEmployees { get; }

        /// <summary>
        /// Получение списка сотрудников
        /// Асинхронная версия
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeeListAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавление сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновление сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удаление сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получение сотрудника по идентификатору
        /// Асинхронная версия
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Employee> GetEmployeeAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Установка нового отдела для сотрудника
        /// Асинхронная версия
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="departmnetId">Идентификатор отдела</param>
        /// <returns></returns>
        Task SetDepartmentAsync(long employeeId, long departmnetId);
    }
}
