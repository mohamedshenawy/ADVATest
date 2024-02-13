using Domain.Entities;
using DomainService.Repo;

namespace DomainService.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : Context.Context, new()
    {

        IRepo<Employee> _employeeRepo;
        IRepo<Department> _departmentRepo;
        public TContext _context { get; }


        public UnitOfWork()
        {
            _context = new TContext();
        }
        public IRepo<Employee> EmployeeRepo
        {
            get
            {
                if (this._employeeRepo == null)
                {
                    this._employeeRepo = new RepoImplementation<Employee>(_context);
                }
                return _employeeRepo;
            }
        }

        public IRepo<Department> DepartmentRepo
        {
            get
            {
                if (this._departmentRepo == null)
                {
                    this._departmentRepo = new RepoImplementation<Department>(_context);
                }
                return _departmentRepo;
            }
        }

        public int Commit()
        {
            int result = 0;
            try
            {
                result = _context.SaveChanges();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
