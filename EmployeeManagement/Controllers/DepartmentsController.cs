using EmployeeManagement.Models;
using EmployeeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class DepartmentsController : Controller
    {
        public DataContext dataContext;

        public DepartmentsController(DataContext ctx)
        {
            dataContext = ctx;
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
            dataContext.Departments.Add(department);
            await dataContext.SaveChangesAsync();

            Employee employee = Deserialize(TempData["employee"] as string);
            employee.DepartmentId = department.Id;

            TempData["employee"] = Serialize(employee);

            return RedirectToAction(
                TempData["returnAction"] as string,
                TempData["returnController"] as string,
                new { id = TempData["employeeId"] as string }
            );
        }

        public IActionResult Index()
        {
            return View(dataContext.Departments.Include(d => d.Employees));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(new DepartmentViewEditModel
            {
                Department = await dataContext.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id),
                Employees = dataContext.Employees
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long employeeId, long departmentId)
        {
            Employee employee = await dataContext.Employees.FindAsync(employeeId);
            employee.DepartmentId = departmentId;

            await dataContext.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = departmentId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long departmentId)
        {
            Department department = await dataContext.Departments.FindAsync(departmentId);
            dataContext.Remove(department);

            await dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public static string GetStaff(Department department)
        {
            var employees = department.Employees.ToList();
            string result = employees.Count == 0
                ? "No staff"
                : string.Join(", ", employees.Take(3).Select(e => e.FirstName).ToArray());
            return employees.Count > 3 ? $"{result} ..." : result;
        }
    }
}
