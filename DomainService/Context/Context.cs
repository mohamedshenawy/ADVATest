using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DomainService.Context
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ADVATest;Integrated Security=True;Encrypt=False");

    }
}