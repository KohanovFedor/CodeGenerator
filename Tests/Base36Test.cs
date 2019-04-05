using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeGenerator;

namespace Tests
{
    [TestClass]
    public class Base36Test
    {
        [TestMethod]
        public void Encode_12345678_7CLZI()
        {
            // Arrange
            string expected = "7CLZI";
            int data = 12345678;
            
            // Act
            var result = Base36.Encode(data);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Encode_minus12345678_ArgumentOutOfRangeException()
        {
            // Arrange
            int data = -12345678;

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> Base36.Encode(data));
        }

        [TestMethod]
        public void Decode_7CLZI_12345678()
        {
            // Arrange
            int expected = 12345678;
            string data = "7CLZI";

            // Act
            var result = Base36.Decode(data);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Decode_null_ArgumentNullException()
        {
            // Arrange
            string data = default;

            // Act

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => Base36.Decode(data));
        }

        [TestMethod]
        public void Decode_7CLZzI_FormatException()
        {
            // Arrange
            string data = "7CLZzI";

            // Act

            // Assert
            Assert.ThrowsException<FormatException>(() => Base36.Decode(data));
        }
    }
}
