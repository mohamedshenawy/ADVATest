using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{

    public class DepartmentViewModel
    {
        public DepartmentDTO Department { get; set; }
        public IEnumerable<EmployeeDTO> AllEmployees { get; set; }
    }
}
