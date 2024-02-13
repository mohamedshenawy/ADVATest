using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentManagerId { get; set; }
        public virtual EmployeeDTO? DepartmentManager { get; set; }

        public virtual List<EmployeeDTO>? Employees { get; set; }
    }
}
