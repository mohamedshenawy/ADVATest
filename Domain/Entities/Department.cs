﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Department : BaseClass
    {
        public string Name { get; set; }
       
        public Employee? DepartmentManager { get; set; }

        [ForeignKey("DepartmentManager")]
        public int? DepartmentManagerId { get; set; }

        [InverseProperty("Department")]
        public virtual List<Employee> Employees { get; set; }
    }
}