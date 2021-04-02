using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrganogram
{
    public class Employee
    {
        public int id;
        public int superiorId;
        string name;
        string surename;
        string company;
        string city;
        string job;
        string firstNumber;
        string secondNumber;
        string thirdNumber;

        public Employee(int id, int superiorId, string name, string surename,
                        string company, string city, string job,
                        string firstNumber, string secondNumber, string thirdNumber)
        {
            this.id = id;
            this.superiorId = superiorId;
            this.name = name;
            this.surename = surename;
            this.company = company;
            this.city = city;
            this.job = job;
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
            this.thirdNumber = thirdNumber;
        }

        public string PrintEmployee()
        {
            return (id + ", " + superiorId + ", " + name + ", " +
                surename + ", " + company + ", " + city + ", " +
                job);
        }
    }
}
