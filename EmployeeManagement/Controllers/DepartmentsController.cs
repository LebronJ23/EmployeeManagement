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
    public class DepartmentsController : Controller
    {
        public IDepartmentService departmentService;
        public IEmployeeService employeeService;

        private IEnumerable<Employee> Employees => employeeService.GetEmployees;

        public DepartmentsController(IDepartmentService dService, IEmployeeService eService)
        {
            departmentService = dService;
            employeeService = eService;
        }

        private string Serialize(Employee e) => JsonSerializer.Serialize(e);
        private Employee Deserialize(string json) => JsonSerializer.Deserialize<Employee>(json);

        public IActionResult Create([FromQuery(Name = "Employee")] Employee employee,
            string returnAction, string returnController = "Home")
        {
            var employeeId = employee.Id.ToString();

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

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Department department)
        {
            await departmentService.AddDepartmentAsync(department);

            var employee = Deserialize(TempData["employee"] as string);
            employee.DepartmentId = department.Id;

            TempData["employee"] = Serialize(employee);

            return RedirectToAction(
                TempData["returnAction"] as string,
                TempData["returnController"] as string,
                new { id = TempData["employeeId"] as string }
            );
        }

        public IActionResult Index(CancellationToken cancellationToken)
        {
            return View(departmentService.GetDepartmentsListAsync(cancellationToken));
        }

        public async Task<IActionResult> Edit(long id, CancellationToken cancellationToken)
        {
            return View(new DepartmentViewEditModel
            {
                Department = await departmentService.GetDepartmentAsync(id, cancellationToken),
                Employees = Employees
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long employeeId, long departmentId)
        {
            await employeeService.SetDepartmentAsync(employeeId, departmentId);
            return RedirectToAction("Edit", new { id = departmentId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long departmentId)
        {
            await departmentService.DeleteDepartmentAsync(departmentId);
            return RedirectToAction("Index");
        }

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
