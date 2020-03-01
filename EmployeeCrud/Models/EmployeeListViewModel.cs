using System.Collections.Generic;

namespace EmployeeCrud.Web.Models
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> EmployeeViewModels { get; set; }

        public bool? FilterActiveEmployee { get; set; }
    }
}