using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CompanyOrganogram;

namespace CompanyOrganogramTests
{
    [TestClass]
    public class DataReaderTests
    {
        [TestMethod]
        public void ReadFromFile_ShouldReturnCorrectListOfEmployees()
        {
            // Arrange
            DataReader dataReader = new DataReader();
            List<EmployeeModel> employeeDataList;
            List<EmployeeModel> expected = new List<EmployeeModel>();
            string fileName = "test_data.csv";

            expected.Add(new EmployeeModel(8, 7, "Christos", "Papazian", "Microsoft", "Johannesburg", "IT Manager", "0765421456", "0115425230", "0115425290"));
            expected.Add(new EmployeeModel(12, 11, "Johan", "Philips", "Oracle", "Johannesburg", "Sales Executive", "0896542114", "0113589743", "0113589743"));
            expected.Add(new EmployeeModel(19, 18, "Samantha", "McFee", "Oracle", "Johannesburg", "Junior Analyst", "0826984512", "0113589799", "0113589798"));


            // Act
            employeeDataList = dataReader.ReadFromFile(fileName);

            // Assert
            CollectionAssert.AreEqual(expected, employeeDataList);
        }
    }
}
