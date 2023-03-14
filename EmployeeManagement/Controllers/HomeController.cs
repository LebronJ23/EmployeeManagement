using EmployeeManagement.Models;
using EmployeeManagement.Models.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.Infrastructure.Factories;
using System.Text.Json;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;

        private IEnumerable<Department> Departments => repository.Departments;
        private IEnumerable<Employee> Employees => repository.Employees;

        public HomeController(IDataRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Employees);
        }

        public IActionResult Create()
        {
            Employee employee = TempData.ContainsKey("employee")
                ? JsonSerializer.Deserialize<Employee>(TempData["employee"] as string)
                : new Employee();

            return View("EmployeeEditor", EmployeeViewModelFactory.Create(employee, Departments));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = default;
                employee.Department = default;

                await repository.CreateEmployeeAsync(employee);

                return RedirectToAction("Index");
            }

            return View("EmployeeEditor", EmployeeViewModelFactory.Create(employee, Departments));
        }

        public async Task<IActionResult> Details(long id)
        {
            Employee employee = await repository.Employees.FirstOrDefaultAsync(e => e.Id == id);

            return View("EmployeeEditor", EmployeeViewModelFactory.Details(employee));
        }

        public async Task<IActionResult> Edit(long id)
        {
            Employee employee = TempData.ContainsKey("employee")
                ? JsonSerializer.Deserialize<Employee>(TempData["employee"] as string)
                : await repository.Employees.FirstOrDefaultAsync(e => e.Id == id);

            return View("EmployeeEditor", EmployeeViewModelFactory.Edit(employee, Departments));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Department = default;

                await repository.SaveEmployeeAsync(employee);

                return RedirectToAction("Index");
            }

            return View("EmployeeEditor", EmployeeViewModelFactory.Edit(employee, Departments));
        }

        public async Task<IActionResult> Delete(long id)
        {
            Employee employee = await repository.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return View("EmployeeEditor", EmployeeViewModelFactory.Delete(employee, Departments));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] Employee employee)
        {
            await repository.DeleteEmployeeAsync(employee);
            return RedirectToAction("Index");
        }
    }
}
