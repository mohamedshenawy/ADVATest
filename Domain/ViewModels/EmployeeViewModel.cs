using Domain.DTO;

namespace Domain.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeDTO Employee { get; set; }
        public IEnumerable<DepartmentDTO> AllDepartments { get; set; }
        public IEnumerable<EmployeeDTO> AllEmployees { get; set; }
    }
}
