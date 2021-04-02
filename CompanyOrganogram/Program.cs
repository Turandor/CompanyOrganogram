using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CompanyOrganogram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var path = Path.Combine(AppContext.BaseDirectory, "..\\companies_data.csv");
            using (var reader = new StreamReader(path))
            {
                List<Employee> employees = new List<Employee>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    employees.Add(new Employee(int.Parse(values[0]), int.Parse(values[1]), 
                                               values[2], values[3], values[4], values[5], 
                                               values[6], values[7], values[8], values[9]));
                }
                //List<Employee> sortedList = Employees.OrderBy(o => o.Id).ThenBy(o => o.Company).ToList();
                List<Employee> sortedList = employees.OrderBy(o => o.Id).ToList();
                Organogram.PrintOrganogram(sortedList);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }


    }
}
