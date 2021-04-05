using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CompanyOrganogram
{
    public class DataReader
    {
        public virtual List<EmployeeModel> ReadFromFile()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "..\\..\\companies_data.csv");
            try
            {
                using (var reader = new StreamReader(path))
                {
                    List<EmployeeModel> employees = new List<EmployeeModel>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        employees.Add(new EmployeeModel(int.Parse(values[0]), int.Parse(values[1]),
                                                   values[2], values[3], values[4], values[5],
                                                   values[6], values[7], values[8], values[9]));
                    }
                    List<EmployeeModel> sortedList = employees.OrderBy(x => x.Id).ToList();
                    return sortedList;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
                return null;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
                return null;
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
                return null;
            }
        }
       
    }
}
