using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication002.Models;

namespace WebApplication002.DAL
{
    public class EmployeeListInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeListContext>
    {
        //Database will be dropped and recreated for testing purposes, later i will use Code First Migration
        protected override void Seed(EmployeeListContext context)
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

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
        }
    }
}