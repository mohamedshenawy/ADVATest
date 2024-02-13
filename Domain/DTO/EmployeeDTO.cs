using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public bool IsManager { get; set; }
        public virtual DepartmentDTO Department { get; set; }
        public int? ManagerId { get; set; }
        public EmployeeDTO? Manager { get; set; }
        public virtual List<EmployeeDTO>? Subordinates { get; set; }
        public virtual List<DepartmentDTO>? ManagedDepartments { get; set; }
    }
}
