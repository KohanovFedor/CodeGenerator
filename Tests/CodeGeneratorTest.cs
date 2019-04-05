using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeGenerator;

namespace Tests
{
    [TestClass]
    public class CodeGeneratorTest
    {
        [TestMethod]
        public void Encode_ffwe_20190119_12345678_ffweJ10J07CLZI()
        {
            // Arrange
            string expected = "ffweJ10J07CLZI";
            string name = "ffwe";
            DateTime date = new DateTime(2019, 1, 19);
            uint account = 12345678;

            // Act
            var result = Generator.Encode(name, date, account);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetCorrectName_null_ArgumentNullException()
        {
            // Arrange
            string name = default;

            // Act

            // Assert
            Assert.ThrowsException<ArgumentNullException>(()=> Generator.GetCorrectName(name));
        }

        [TestMethod]
        public void GetCorrectName_ffwerthrtrtbrb_ffwerthr()
        {
            // Arrange
            string expected = "ffwerthr";
            string name = "ffwerthrtrtbrb";

            // Act
            var result = Generator.GetCorrectName(name);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetEncodeDate_32960119_ArgumentOutOfRangeException()
        {
            // Arrange
            DateTime date = new DateTime(3296, 1, 19);

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> Generator.GetEncodeDate(date));
        }

        [TestMethod]
        public void GetEncodeAccount_100000000_ArgumentOutOfRangeException()
        {
            // Arrange
            uint account = 100000000;

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.GetEncodeAccount(account));
        }

        [TestMethod]
        public void GetEncodeAccount_ffwe_20190119_0_ArgumentOutOfRangeException()
        {
            // Arrange
            uint account = 0;

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.GetEncodeAccount(account));
        }

        [TestMethod]
        public void Decode_ffweJ10J07CLZI_ffwe_20190119_12345678()
        {
            // Arrange
            string dataStr = "ffweJ10J07CLZI";
            (string name, DateTime date, uint account) expected = default;
            expected.name = "ffwe";
            expected.date = new DateTime(2019, 1, 19);
            expected.account = 12345678;

            // Act
            var result = Generator.Decode(dataStr);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Decode_J10J07CLZI_ArgumentException()
        {
            // Arrange
            string dataStr = "J10J07CLZI";

            // Act
            
            // Assert
            Assert.ThrowsException<ArgumentException>(()=> Generator.Decode(dataStr));
        }

    }
}
