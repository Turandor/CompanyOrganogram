using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using CompanyOrganogram;
using Moq;

namespace CompanyOrganogramTests
{
    [TestClass]
    public class DataReaderTests
    {
        Mock dataReaderMock;

        [TestMethod]
        public void ReadFromFile_Should()
        {
            dataReaderMock = new Mock<DataReader>();
        }
    }
}
