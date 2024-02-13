using Domain.Entities;
using DomainService.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.UnitOfWork
{
    public interface IUnitOfWork<out TContext> where TContext : Context.Context, new()
    {
        public IRepo<Employee> EmployeeRepo { get;}
        public IRepo<Department> DepartmentRepo { get; }
        public TContext _context { get; }
        public int Commit();

    }
}
