using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CompanyOrganogram;
using Moq;

namespace CompanyOrganogramTests
{
    [TestClass]
    public class OrganogramTests
    {
        [TestMethod]
        public void BuildOrganogram_ShouldBuildCorrectOrganogram()
        {
            // Arrange
            var dataReaderMock = new Mock<DataReader>(); // Mock of Data Reader
            LineWriter lineWriter = new LineWriter();

            List<EmployeeModel> employeeModelList = new List<EmployeeModel>();
            
            //Test Data
            EmployeeModel model1 = new EmployeeModel(3, 0, "A", "A", "A", "A", "A", "1", "2", "3");
            EmployeeModel model2 = new EmployeeModel(1, 2, "B", "B", "B", "B", "B", "1", "2", "3");
            EmployeeModel model3 = new EmployeeModel(4, 2, "C", "C", "B", "C", "C", "1", "2", "3");
            EmployeeModel model4 = new EmployeeModel(2, 0, "D", "D", "B", "D", "D", "1", "2", "3");
            EmployeeModel model5 = new EmployeeModel(5, 1, "E", "E", "B", "E", "E", "1", "2", "3");

            employeeModelList.Add(model1);
            employeeModelList.Add(model2);
            employeeModelList.Add(model3);
            employeeModelList.Add(model4);
            employeeModelList.Add(model5);
            
            // Manual creating of organogram
            Employee employee1 = new Employee(model1, 0);
            Employee employee3 = new Employee(model3, 1);
            Employee employee5 = new Employee(model5, 2);
            List<Employee> inferiorList2 = new List<Employee>();
            inferiorList2.Add(employee5);
            Employee employee2 = new Employee(model2, inferiorList2, 1);
            List<Employee> expected = new List<Employee>();
            List<Employee> inferiorList4 = new List<Employee>();
            inferiorList4.Add(employee2);
            inferiorList4.Add(employee3);
            Employee employee4 = new Employee(model4, inferiorList4, 0);

            expected.Add(employee1);
            expected.Add(employee4);


            dataReaderMock.Setup(x => x.ReadFromFile(It.IsAny<string>())).Returns(employeeModelList); // Mock method
            Organogram organogram = new Organogram(lineWriter, dataReaderMock.Object); 

            // Act
            List<Employee> outputOgranogram = organogram.BuildOrganogram();

            // Assert
            CollectionAssert.AreEqual(expected, outputOgranogram);
        }
    }
}

