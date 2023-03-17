using EmployeeManagement.Models;
using EmployeeManagement.Models.Infrastructure.Interfaces.Services;
using EmployeeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    /// <summary>
    /// Контроллер отделов
    /// </summary>
    public class DepartmentsController : Controller
    {
        // Сервис по работе с отделами
        public IDepartmentService departmentService;

        // Сервис по работе с сотрудниками
        public IEmployeeService employeeService;

        // Все сотрудники
        private IEnumerable<Employee> Employees => employeeService.GetEmployees;

        public DepartmentsController(IDepartmentService dService, IEmployeeService eService)
        {
            departmentService = dService;
            employeeService = eService;
        }

        private string Serialize(Employee e) => JsonSerializer.Serialize(e);
        private Employee Deserialize(string json) => JsonSerializer.Deserialize<Employee>(json);

        /// <summary>
        /// Создание отдела
        /// </summary>
        /// <param name="employee">Сотрудник, для которого создается новый отдел</param>
        /// <param name="returnAction">Метод действия, с которого происходит вызов создания отдела</param>
        /// <param name="returnController">Котроллен действия, с которого происходит вызов создания отдела</param>
        /// <returns></returns>
        public IActionResult Create([FromQuery(Name = "Employee")] Employee employee,
            string returnAction, string returnController = "Home")
        {
            var employeeId = employee.Id.ToString();

            // Сериализация сотрудника для восстановления данных о нем и возврата в исходную точку
            // после создания нового отдела
            TempData["employee"] = Serialize(employee);
            TempData["returnAction"] = returnAction;
            TempData["returnController"] = returnController;
            TempData["employeeId"] = employeeId;

            return View(new DepartmentViewCreateModel 
            { 
                Department = new Department(), 
                EmployeeId = employeeId, 
                ReturnAction = returnAction,
                ReturnController = returnController
            });
        }

        /// <summary>
        /// Создание отдела
        /// </summary>
        /// <param name="department">отдел для создания</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Department department)
        {
            await departmentService.AddDepartmentAsync(department);

            // Установка нового департамента сотруднику
            var employee = Deserialize(TempData["employee"] as string);
            employee.DepartmentId = department.Id;

            TempData["employee"] = Serialize(employee);

            // Возврат в точку, из которой произошел вызов создания отдела
            return RedirectToAction(
                TempData["returnAction"] as string,
                TempData["returnController"] as string,
                new { id = TempData["employeeId"] as string }
            );
        }

        /// <summary>
        /// Отображение списка отделов
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public IActionResult Index(CancellationToken cancellationToken)
        {
            return View(departmentService.GetDepartmentsListAsync(cancellationToken));
        }

        /// <summary>
        /// Редактирование отдела
        /// </summary>
        /// <param name="id">Идентификатор отдела</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id, CancellationToken cancellationToken)
        {
            return View(new DepartmentViewEditModel
            {
                Department = await departmentService.GetDepartmentAsync(id, cancellationToken),
                Employees = Employees
            });
        }

        /// <summary>
        /// Редактирование отдела
        /// Перенос сотрудника в текущий отдел
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="departmentId">Идентификатор отдела</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(long employeeId, long departmentId)
        {
            await employeeService.SetDepartmentAsync(employeeId, departmentId);
            return RedirectToAction("Edit", new { id = departmentId });
        }

        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <param name="departmentId">Идентификатор отдела</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(long departmentId)
        {
            await departmentService.DeleteDepartmentAsync(departmentId);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Получение списка сотрудников отдела в виде строки
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static string GetStaff(Department department)
        {
            var employees = department.Employees.ToList();
            var result = employees.Any()
                ? "No staff"
                : string.Join(", ", employees.Take(3).Select(e => e.FirstName).ToArray());
            return employees.Count > 3 ? $"{result} ..." : result;
        }
    }
}
