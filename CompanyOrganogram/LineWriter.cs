using System;
using System.Text;

namespace CompanyOrganogram
{
    public class LineWriter
    {
        public void WriteLine(Employee employee)
        {
            StringBuilder sb = new StringBuilder(TextIndent(employee.HierarchyLevel));
            sb.Append(employee.employeeData.Id + ", ");
            sb.Append(employee.employeeData.SuperiorId + ", ");
            sb.Append(employee.employeeData.Name + ", ");
            sb.Append(employee.employeeData.Surename + ", ");
            sb.Append(employee.employeeData.Company + ", ");
            sb.Append(employee.employeeData.City + ", ");
            sb.Append(employee.employeeData.Job);
            
            Console.WriteLine(sb);
        }

        public string TextIndent(int level)
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
