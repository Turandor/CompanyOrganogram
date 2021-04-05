using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CompanyOrganogram;

namespace CompanyOrganogramTests
{
    [TestClass]
    public class LineWriterTests
    {
        [TestMethod]
        public void TextIndent_WithValidLevel_ReturnsGoodIndent()
        {
            // Arrange
            LineWriter lineWriter = new LineWriter();
            int level = 5;
            string expected = "                    --> ";
            string output;
            // Act
            output = lineWriter.TextIndent(level);

            // Assert
            Assert.AreEqual(expected, output, "Text indent is not correct");
        }

        [TestMethod]
        public void TextIndent_WithZeroLevel_ReturnsEmptyIndent()
        {
            // Arrange
            LineWriter lineWriter = new LineWriter();
            int level = 0;
            string expected = "";
            string output;
            // Act
            output = lineWriter.TextIndent(level);

            // Assert
            Assert.AreEqual(expected, output, "Text indent is not correct");
        }

        [TestMethod]
        public void WriteLine_ShouldDisplayCorrectText()
        {
            using (var sw = new StringWriter())
            {
                // Arrange
                LineWriter lineWriter = new LineWriter();
                Console.SetOut(sw);
                int hierarchyLevel = 0;
                EmployeeModel employeeModel = new EmployeeModel(1, 0, "A", "B", "C", "D", "E", "1", "2", "3");
                Employee employee = new Employee(employeeModel, hierarchyLevel);
                string expected = "1, 0, A, B, C, D, E";

                // Act
                lineWriter.WriteLine(employee);
                var result = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expected, result, "Employee was not corectly displayed");
            }
        }
    }
}
