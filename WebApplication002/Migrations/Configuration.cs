
namespace WebApplication002.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication002.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication002.DAL.EmployeeListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication002.DAL.EmployeeListContext";
        }

        protected override void Seed(WebApplication002.DAL.EmployeeListContext context)
        {
            var employees = new List<Employee>
            {
            new Employee{FirstName="Olegas",LastName="Karpavicius", SalaryNeto = 900},
            new Employee{FirstName="Marija",LastName="Morkeviciute", SalaryNeto = 1900},
            new Employee{FirstName="Ausra",LastName="Draugelaite", SalaryNeto = 800},
            new Employee{FirstName="Tomas",LastName="Gedavicius", SalaryNeto = 1000},
            new Employee{FirstName="Laurynas",LastName="Petriulis", SalaryNeto = 1100},
            new Employee{FirstName="Kamile",LastName="Butkute", SalaryNeto = 650},
            new Employee{FirstName="Kazimieras",LastName="Zuikinas", SalaryNeto = 725},
            new Employee{FirstName="Zita",LastName="Katriene", SalaryNeto = 1324},
            new Employee{FirstName="Mantas",LastName="Ozaitis", SalaryNeto = 2432},
            new Employee{FirstName="Vida",LastName="Martinaite", SalaryNeto = 1687},
            };
            employees.ForEach(s => context.Employees.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
        }
    }
}
