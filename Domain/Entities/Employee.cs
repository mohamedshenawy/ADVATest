using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Employee : BaseClass
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }


        [InverseProperty("Manager")]
        public virtual List<Employee>? Subordinates { get; set; }

        [InverseProperty("DepartmentManager")]
        public virtual List<Department>? ManagedDepartments { get; set; }

    }
}