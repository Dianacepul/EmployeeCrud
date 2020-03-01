using EmployeeCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Repo
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new EmployeeMap(modelBuilder.Entity<Employee>());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}