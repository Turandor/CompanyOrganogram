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
    }
}
