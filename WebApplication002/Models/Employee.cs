using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication002.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SalaryNeto { get; set; }
        public decimal SalaryBruto => SalaryNeto * 3;
    }
}