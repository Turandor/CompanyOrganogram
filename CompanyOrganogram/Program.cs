using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompanyOrganogram
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "..\\companies_data.csv");
            using (var reader = new StreamReader(path))
            {
                List<Employee> Employees = new List<Employee>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Employees.Add(new Employee(int.Parse(values[0]), int.Parse(values[1]), 
                                               values[2], values[3], values[4], values[5], 
                                               values[6], values[7], values[8], values[9]));
                }
                List<Employee> sortedList = Employees.OrderBy(o => o.id).ToList();
                PrintOrganogram(sortedList);
            }

            Console.ReadKey();
        }

        static void PrintOrganogram(List<Employee> employees)
        {
            foreach (var item in employees)
            {
                if (item.superiorId == 0)
                {
                    //employees.Remove(item);
                    Console.WriteLine(item.PrintEmployee());
                    FindInferiors(item, employees, 1);
                }

            }
        }
        
        static void FindInferiors(Employee superior, List<Employee> employees, int level)
        {
            foreach (var item in employees)
            {
                if (superior.id == item.superiorId)
                {
                    Console.WriteLine(ParagraphIndent(level) + item.PrintEmployee());
                    //employees.Remove(item);
                    FindInferiors(item, employees, level+1);
                }
            }
        }
        static string ParagraphIndent(int level)
        {
            string paragraphIndent = "";
            for (int i = 0; i < level; i++)
            {
                paragraphIndent += "    ";
            }
            return paragraphIndent;
        }
    }
}
