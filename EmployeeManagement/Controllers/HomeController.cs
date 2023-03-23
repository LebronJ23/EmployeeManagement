using EmployeeManagement.Models;
using EmployeeManagement.Models.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.Infrastructure.Factories;
using System.Text.Json;
using System.Threading;
using EmployeeManagement.Models.Infrastructure.Interfaces.Services;

namespace EmployeeManagement.Controllers
{
    /// <summary>
    /// Контроллер сотрудников
    /// </summary>
    public class HomeController : Controller
    {
        // Сервис по работе с сотрудниками
        private IEmployeeService employeeService;

        // Сервис по работе с отделами
        private IDepartmentService departmentService;

        // Все отделы
        private IEnumerable<Department> Departments => departmentService.GetDepartments;

        public HomeController(IEmployeeService eService, IDepartmentService dService)
        {
            employeeService = eService;
            departmentService = dService;
        }

        /// <summary>
        /// Отображение списка сотрудников
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await employeeService.GetEmployeeListAsync(cancellationToken));
        }

        /// <summary>
        /// Создание сотрудника
        /// При создании сотрудника и последующем переходе на создание отдела, необходимо выполнить десереализацию
        /// заполненных ранее данных для их восстановления, вместо того, чтобы опять обнулять поля
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var employee = TempData.ContainsKey("employee")
                ? JsonSerializer.Deserialize<Employee>(TempData["employee"] as string)
                : new Employee();

            return View("EmployeeEditor", EmployeeViewModelFactory.Create(employee, Departments));
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.AddEmployeeAsync(employee);

                return RedirectToAction("Index");
            }

            return View("EmployeeEditor", EmployeeViewModelFactory.Create(employee, Departments));
        }

        /// <summary>
        /// Детальная информация по сотруднику
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(long id, CancellationToken cancellationToken)
        {
            var employee = await employeeService.GetEmployeeAsync(id, cancellationToken);

            return View("EmployeeEditor", EmployeeViewModelFactory.Details(employee));
        }

        /// <summary>
        /// Редактирование сотрудника
        /// При создании нового отдела во время редактирования сотрудника производятся такие же действия
        /// по сериализации/десереализации, как и при создании сотрудника
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id, CancellationToken cancellationToken)
        {
            var employee = TempData.ContainsKey("employee")
                ? JsonSerializer.Deserialize<Employee>(TempData["employee"] as string)
                : await employeeService.GetEmployeeAsync(id, cancellationToken);

            return View("EmployeeEditor", EmployeeViewModelFactory.Edit(employee, Departments));
        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.UpdateEmployeeAsync(employee);

                return RedirectToAction("Index");
            }

            return View("EmployeeEditor", EmployeeViewModelFactory.Edit(employee, Departments));
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            var employee = await employeeService.GetEmployeeAsync(id, cancellationToken);
            return View("EmployeeEditor", EmployeeViewModelFactory.Delete(employee, Departments));
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] Employee employee)
        {
            await employeeService.DeleteEmployeeAsync(employee);
            return RedirectToAction("Index");
        }
    }
}
