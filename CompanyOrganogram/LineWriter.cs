using System;
using System.Text;

namespace CompanyOrganogram
{
    public class LineWriter
    {
        
        public void WriteLine(Employee employee)
        {
            StringBuilder sb = new StringBuilder(TextIndent(employee.HierarchyLevel));
            sb.Append(employee.employeeData.Id + ", " +
                employee.employeeData.SuperiorId + ", " +
                employee.employeeData.Name + ", " +
                employee.employeeData.Surename + ", " +
                employee.employeeData.Company + ", " +
                employee.employeeData.City + ", " +
                employee.employeeData.Job);
            Console.WriteLine(sb);
        }

        public static string TextIndent(int level)
        {
            StringBuilder paragraphIndent = new StringBuilder("");
            if (level > 0)
            {
                for (int i = 0; i < level; i++)
                {
                    paragraphIndent.Append("    ");
                }
                paragraphIndent.Append("--> ");
            }
            return paragraphIndent.ToString();
        }
    }
}
