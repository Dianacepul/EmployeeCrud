using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud.Web.Models
{
    public class EmployeeViewModel
    {
        [Display(Name = "Unikalus numeris")]
        public int Id { get; set; }

        [Display(Name = "Asmens kodas")]
        [Required]
        public int PersonalNumber { get; set; }

        [Display(Name = "Vardas")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Pavardė")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Adresas")]
        public string Address { get; set; }

        [Display(Name = "Gimimo data")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Dirba")]
        [Required]
        public bool IsActive { get; set; }
    }
}