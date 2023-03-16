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
    public class HomeController : Controller
    {
        private IEmployeeService employeeService;
        private IDepartmentService departmentService;

        private IEnumerable<Department> Departments => departmentService.GetDepartments;

        public HomeController(IEmployeeService eService, IDepartmentService dService)
        {
            employeeService = eService;
            departmentService = dService;
        }

        public IActionResult Index(CancellationToken cancellationToken)
        {
            return View(employeeService.GetEmployeeListAsync(cancellationToken));
        }

        public IActionResult Create()
        {
            var employee = TempData.ContainsKey("employee")
                ? JsonSerializer.Deserialize<Employee>(TempData["employee"] as string)
                : new Employee();

            return View("EmployeeEditor", EmployeeViewModelFactory.Create(employee, Departments));
        }

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

        public async Task<IActionResult> Details(long id, CancellationToken cancellationToken)
        {
            var employee = await employeeService.GetEmployeeAsync(id, cancellationToken);

            return View("EmployeeEditor", EmployeeViewModelFactory.Details(employee));
        }

        public async Task<IActionResult> Edit(long id, CancellationToken cancellationToken)
        {
            var employee = TempData.ContainsKey("employee")
                ? JsonSerializer.Deserialize<Employee>(TempData["employee"] as string)
                : await employeeService.GetEmployeeAsync(id, cancellationToken);

            return View("EmployeeEditor", EmployeeViewModelFactory.Edit(employee, Departments));
        }

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

        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            var employee = await employeeService.GetEmployeeAsync(id, cancellationToken);
            return View("EmployeeEditor", EmployeeViewModelFactory.Delete(employee, Departments));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] Employee employee)
        {
            await employeeService.DeleteEmployeeAsync(employee);
            return RedirectToAction("Index");
        }
    }
}
