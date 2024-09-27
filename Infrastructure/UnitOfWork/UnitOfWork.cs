using Domain.Entities;
using DomainService.Repo;
using DomainService.UnitOfWork;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        IRepo<Employee> _employeeRepo;
        IRepo<Department> _departmentRepo;
        protected Context.Context _context { get; }


        public UnitOfWork(Context.Context myContext)
        {
            _context = myContext;
        }
        public IRepo<Employee> EmployeeRepo
        {
            get
            {
                if (_employeeRepo == null)
                {
                    _employeeRepo = new RepoImplementation<Employee>(_context);
                }
                return _employeeRepo;
            }
        }

        public IRepo<Department> DepartmentRepo
        {
            get
            {
                if (_departmentRepo == null)
                {
                    _departmentRepo = new RepoImplementation<Department>(_context);
                }
                return _departmentRepo;
            }
        }

        public int Commit()
        {
            int result = _context.SaveChanges();
            return result;
        }
    }
}
