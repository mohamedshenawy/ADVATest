using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) 
            : base(options)
        { }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Department> Department { get; set; }
    }
}