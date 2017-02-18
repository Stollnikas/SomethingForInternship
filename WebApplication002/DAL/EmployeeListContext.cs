using WebApplication002.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace WebApplication002.DAL
{
    public class EmployeeListContext : DbContext
    {
        public EmployeeListContext() : base("EmployeeListContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}