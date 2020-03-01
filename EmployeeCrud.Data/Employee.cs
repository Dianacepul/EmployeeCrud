using System;

namespace EmployeeCrud.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public int PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsActive { get; set; }
    }
}