using static System.Convert;
using static System.Decimal;

namespace WebApplication002.Models
{
    public class Employee
    {
        //Employee Class properties, names are pretty self explanatory
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SalaryNeto { get; set; }

        //SalaryBruto has only getter, because the value is not saved anywhere, and is calculated from the Neto salary of the employee.
        public decimal SalaryBruto
        {
            get
            {
                if (SalaryNeto >= 760)
                {
                    //Calculate when neto is more then 760 (Bruto is 1000), then NPD reaches 0 and should be excluded.
                    var x = SalaryNeto * ToDecimal(1.315789473684211);
                    return x;
                }
                else
                {
                    //Calculating when Neto salary is below 760
                    var x = Multiply(SalaryNeto, ToDecimal(1.45985)) - ToDecimal(109.489);
                    return x;
                }
            }
        }
    }
}