using System.Collections.Generic;

namespace CompanyOrganogram
{
    public class Organogram
    {
        public List<Employee> bossesList;
        public LineWriter lineWriter;
        public DataReader dataReader;

        public Organogram(LineWriter lineWriter, DataReader dataReader)
        {
            this.lineWriter = lineWriter;
            this.dataReader = dataReader;
        }

        public void BuildOrganogram()
        {
            List<EmployeeModel> unorganizedEmployees = new List<EmployeeModel>();
            bossesList = new List<Employee>();

            unorganizedEmployees = dataReader.ReadFromFile();


            int startLevel = 0;
            foreach (var employee in unorganizedEmployees)
            {
                if (employee.SuperiorId == 0)
                {
                    bossesList.Add(new Employee(employee, 
                        FindInferiors(employee, unorganizedEmployees.
                        FindAll(x => x.Company == employee.Company),
                        startLevel),startLevel));
                }
            }
        }

        public List<Employee> FindInferiors(EmployeeModel superior, List<EmployeeModel> employeeDataList, int level)
        {
            List<Employee> inferiorsList = new List<Employee>();
            foreach (var employeeData in employeeDataList)
            {
                if (superior.Id == employeeData.SuperiorId)
                {
                    inferiorsList.Add(new Employee(employeeData, 
                        FindInferiors(employeeData, employeeDataList, level + 1), level+1));               
                }
            }
            return inferiorsList;
        }

        public void PrintOrganogram(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                lineWriter.WriteLine(employee);
                if (employee.inferiors.Count != 0)
                    PrintOrganogram(employee.inferiors);
            }
        }
    }
}
