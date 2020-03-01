using EmployeeCrud.Data;
using EmployeeCrud.Repo;
using System.Collections.Generic;

namespace EmployeeCrud.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return employeeRepository.Get(id);
        }

        public IEnumerable<Employee> GetActiveEmployees()
        {
            return employeeRepository.GetAllActive();
        }

        public IEnumerable<Employee> GetNotActiveEmployees()
        {
            return employeeRepository.GetAllNotActive();
        }

        public void InsertEmployee(Employee employee)
        {
            employeeRepository.Insert(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            employeeRepository.Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employee.IsActive = false;
            employeeRepository.Update(employee);
        }
    }
}