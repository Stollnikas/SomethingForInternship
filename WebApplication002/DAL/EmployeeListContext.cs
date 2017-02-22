using WebApplication002.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace WebApplication002.DAL
{
    public class EmployeeListContext : DbContext
    {
        //Specifying connection string
        public EmployeeListContext() : base("EmployeeListContext")
        {
        }

        //Specifying entity set
        public DbSet<Employee> Employees { get; set; }

        //This snippet here is to remove pluralization of table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}