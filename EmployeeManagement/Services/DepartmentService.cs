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
    /// Сервис по работе с отделами
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        private IDataRepository Repository { get; }

        public DepartmentService(IDataRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Список отделов
        /// </summary>
        public IEnumerable<Department> GetDepartments => Repository.Departments;

        /// <summary>
        /// Добавление нового отдела
        /// Асинхронная версия
        /// </summary>
        /// <param name="department">Отдел</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddDepartmentAsync(Department department, CancellationToken cancellationToken = default)
        {
            await Repository.CreateDepartmentAsync(department);
        }

        /// <summary>
        /// Удаление отдела
        /// Асинхронная версия
        /// </summary>
        /// <param name="department">Отдел</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteDepartmentAsync(Department department, CancellationToken cancellationToken = default)
        {
            await Repository.DeleteDepartmentAsync(department);
        }

        /// <summary>
        /// Получение отдела
        /// Асинхронная версия
        /// </summary>
        /// <param name="id">Идентификатор отдела</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Department> GetDepartmentAsync(long id, CancellationToken cancellationToken)
        {
            return await Repository.FindDepartmentByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Получение списка отделов
        /// Асинхронная версия
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ConfiguredCancelableAsyncEnumerable<Department> GetDepartmentsListAsync(CancellationToken cancellationToken)
        {
            return Repository.Departments.AsAsyncEnumerable().WithCancellation(cancellationToken);
        }

        /// <summary>
        /// Обновление отдела
        /// Асинхронная версия
        /// </summary>
        /// <param name="department">Отдел</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateDepartmentAsync(Department department, CancellationToken cancellationToken = default)
        {
            await Repository.SaveDepartmentAsync(department);
        }

        /// <summary>
        /// Удаление отдела по идентификатору
        /// Асинхронная версия
        /// </summary>
        /// <param name="id">Идентификатор отдела</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteDepartmentAsync(long id, CancellationToken cancellationToken = default)
        {
            var department = await Repository.FindDepartmentByIdAsync(id);
            await Repository.DeleteDepartmentAsync(department);
        }
    }
}
