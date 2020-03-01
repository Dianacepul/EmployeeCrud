using EmployeeCrud.Data;
using System.Collections.Generic;

namespace EmployeeCrud.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();

        Employee GetEmployee(int id);

        IEnumerable<Employee> GetActiveEmployees();

        IEnumerable<Employee> GetNotActiveEmployees();

        void InsertEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}