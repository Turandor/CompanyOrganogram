using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrganogram
{
    public static class Organogram
    {
        public static void PrintOrganogram(List<Employee> employees)
        {
            foreach (var item in employees)
            {
                if (item.SuperiorId == 0)
                {
                    Console.WriteLine(item.PrintEmployee());
                    //List<Employee> companyEmployees = employees.FindAll(x => x.Company == item.Company);
                    FindInferiors(item, employees.FindAll(x => x.Company == item.Company), 1);
                    //FindInferiors(item, employees, 1);
                }
            }
        }

        public static void FindInferiors(Employee superior, List<Employee> employees, int level)
        {
            foreach (var item in employees)
            {
                if (superior.Id == item.SuperiorId)
                {
                    Console.WriteLine(TextIndent(level) + item.PrintEmployee());
                    FindInferiors(item, employees, level + 1);
                }
            }
        }
        public static string TextIndent(int level)
        {
            string paragraphIndent = "";
            for (int i = 0; i < level; i++)
            {
                paragraphIndent += "    ";
            }
            paragraphIndent += "--> ";
            return paragraphIndent;
        }
    }
}
