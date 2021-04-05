using System.Collections.Generic;

namespace CompanyOrganogram
{
    public class Employee
    {
        public EmployeeModel employeeData;
        public List<Employee> inferiors = new List<Employee>();
        public int HierarchyLevel { get; set; }

        public Employee (EmployeeModel employeeData, List<Employee> inferiors, int hierarchyLevel)
        {
            this.employeeData = employeeData;
            HierarchyLevel = hierarchyLevel;
            if (inferiors.Count != 0)
                this.inferiors = inferiors;
        }
        public Employee(EmployeeModel employeeData, int hierarchyLevel)
        {
            this.employeeData = employeeData;
            HierarchyLevel = hierarchyLevel;
        }

        //Equals override for unit test
        public override bool Equals(object obj)
        {
            if (employeeData.Id == ((Employee)obj).employeeData.Id)
            {
                if (inferiors.Count == ((Employee)obj).inferiors.Count)
                {
                    if (inferiors.Count == 0)
                        return true;
                    else
                    {
                        for (int i = 0; i < inferiors.Count; i++)
                        {
                            if (!inferiors[i].Equals(((Employee)obj).inferiors[i]))
                                return false;
                        }
                        return true;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
