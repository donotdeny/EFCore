using EFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Domain.Impl.Sql.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Salary> Salary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\An,1433;Database=ef_core_db;Trusted_Connection=true;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            //Property Configurations
            builder.Entity<Employee>()
                .HasOne(s => s.Department)
                .WithMany(g => g.Employees)
                .HasForeignKey(s => s.CurrentDepartmentId);
            builder.Entity<Salary>()
                .HasOne(s => s.Employee)
                .WithMany(g => g.Salaries)
                .HasForeignKey(s => s.CurrentEmployeeId);
        }
    }
}
