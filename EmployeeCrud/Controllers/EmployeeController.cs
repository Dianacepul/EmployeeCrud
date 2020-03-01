using EmployeeCrud.Data;
using EmployeeCrud.Service;
using EmployeeCrud.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeCrud.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index(EmployeeListViewModel model)
        {
            model.EmployeeViewModels = new List<EmployeeViewModel>();
            List<Employee> employees = null;

            if (!model.FilterActiveEmployee.HasValue)
            {
                employees = employeeService.GetAll().ToList();
            }
            else if (model.FilterActiveEmployee.Value)
            {
                employees = employeeService.GetActiveEmployees().ToList();
            }
            else
            {
                employees = employeeService.GetNotActiveEmployees().ToList();
            }
            foreach (var employee in employees)
            {
                model.EmployeeViewModels.Add(new EmployeeViewModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    Birthday = employee.Birthday,
                    IsActive = employee.IsActive
                });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            return View("AddEmployee", model);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel model)
        {
            Employee employeeEntity = new Employee
            {
                Id = model.Id,
                PersonalNumber = model.PersonalNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Birthday = model.Birthday,
                IsActive = model.IsActive
            };
            employeeService.InsertEmployee(employeeEntity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            if (id.HasValue && id != 0)
            {
                Employee employeeEntity = employeeService.GetEmployee(id.Value);
                model.Id = employeeEntity.Id;
                model.PersonalNumber = employeeEntity.PersonalNumber;
                model.FirstName = employeeEntity.FirstName;
                model.LastName = employeeEntity.LastName;
                model.Address = employeeEntity.Address;
                model.Birthday = employeeEntity.Birthday;
                model.IsActive = employeeEntity.IsActive;
            }

            return View("EditEmployee", model);
        }

        [HttpPost]
        public IActionResult EditEmployee(EmployeeViewModel model)
        {
            Employee employeeEntity = employeeService.GetEmployee(model.Id);
            employeeEntity.PersonalNumber = model.PersonalNumber;
            employeeEntity.FirstName = model.FirstName;
            employeeEntity.LastName = model.LastName;
            employeeEntity.Address = model.Address;
            employeeEntity.Birthday = model.Birthday;
            employeeEntity.IsActive = model.IsActive;

            employeeService.UpdateEmployee(employeeEntity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employeeEntity = employeeService.GetEmployee(id);

            employeeService.DeleteEmployee(employeeEntity);
            return RedirectToAction("Index");
        }
    }
}