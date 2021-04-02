using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using CompanyOrganogram;

namespace CompanyOrganogramTests
{
    [TestClass]
    public class OrganogramTests
    {
        [TestMethod]
        public void FindInferiors_ShouldFindAllInferiors()
        {
            // Arrange
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(1, 0, "John", "Johnson", "AAA", "city", "director", "1", "2", "3"));
            employees.Add(new Employee(2, 1, "Adam", "Adamczewski", "AAA", "city", "technical director", "1", "2", "3"));
            employees.Add(new Employee(3, 0, "Gordon", "Brown", "BBB", "city", "director", "1", "2", "3"));
            employees.Add(new Employee(4, 1, "Albert", "Zweistein", "AAA", "city", "marketing director", "1", "2", "3"));
            //chujów sto to nie moze tak byc xD
            string expected = "--> 2, 1, Adam, Adamczewski, AAA, city, technical director\n        --> 4, 1, Albert, Zweistein, AAA, city, marketing director";
            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CompanyOrganogram.Organogram.FindInferiors(employees[0], employees, 0);

                var result = sw.ToString();
            // Assert
                Assert.AreEqual(expected, result);
            }


        }

        [TestMethod]
        public void TextIndent_WithValidLevel_ReturnsGoodIndent()
        {
            // Arrange
            int level = 5;
            string expected = "                    --> ";
            string output;
            // Act
            output = CompanyOrganogram.Organogram.TextIndent(level);

            // Assert
            Assert.AreEqual(expected, output, "Text indent is not correct");
        }

    }
}
