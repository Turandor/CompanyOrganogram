using System.Collections.Generic;
using System;

namespace CompanyOrganogram
{
    public class Organogram
    {
        readonly LineWriter lineWriter;
        readonly DataReader dataReader;
        readonly string fileName = "companies_data.csv";

        public Organogram(LineWriter lineWriter, DataReader dataReader)
        {
            this.lineWriter = lineWriter;
            this.dataReader = dataReader;
        }

        public List<Employee> BuildOrganogram()
        {
            List<EmployeeModel> unorganizedEmployees = new List<EmployeeModel>();
            List<Employee> bossesList = new List<Employee>();

            int startLevel = 0;
            unorganizedEmployees = dataReader.ReadFromFile(fileName);

            if (unorganizedEmployees != null)
            {
                foreach (var employee in unorganizedEmployees)
                {
                    if (employee.SuperiorId == 0)
                    {
                        bossesList.Add(new Employee(employee,
                            FindInferiors(employee, unorganizedEmployees.
                            FindAll(x => x.Company == employee.Company),
                            startLevel), startLevel));
                    }
                }
                return bossesList;
            }
            else
                return null;
        }

        List<Employee> FindInferiors(EmployeeModel superior, List<EmployeeModel> employeeDataList, int level)
        {
            List<Employee> inferiorsList = new List<Employee>();
            foreach (var employeeData in employeeDataList)
            {
                if (superior.Id == employeeData.SuperiorId)
                {
                    inferiorsList.Add(new Employee(employeeData, 
                        FindInferiors(employeeData, employeeDataList, level + 1), level + 1));               
                }
            }
            return inferiorsList;
        }

        public void PrintOrganogram(List<Employee> employees)
        {
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    lineWriter.WriteLine(employee);
                    if (employee.inferiors.Count != 0)
                        PrintOrganogram(employee.inferiors);
                }
            }
            else
                Console.WriteLine("Cannot print empty organogram!");
        }
    }
}
