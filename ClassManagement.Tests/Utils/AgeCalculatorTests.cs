using ClassManagement.Api.Helpers;
using NUnit.Framework;
using System;

namespace ClassManagement.Tests
{


    [TestFixture]
    public class AgeCalculatorTests
    {
        [Test]
        public void IsOver22_ReturnsTrue_WhenPersonIsOver22YearsOld()
        {
            // Arrange
            DateTime dateOfBirth = new DateTime(1990, 1, 1);


            // Act
            bool result = Utils.IsOver22(dateOfBirth);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOver22_ReturnsTrue_WhenPersonWillTurn22ThisYear()
        {
            // Arrange
            DateTime dateOfBirth = new DateTime(2000, 12, 31);
       

            // Act
            bool result = Utils.IsOver22(dateOfBirth);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOver22_ReturnsFalse_WhenPersonIsUnder22YearsOld()
        {
            // Arrange
            DateTime dateOfBirth = new DateTime(2005, 1, 1);
          

            // Act
            bool result = Utils.IsOver22(dateOfBirth);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsOver22_ReturnsFalse_WhenDateOfBirthIsNull()
        {
            // Arrange
            DateTime? dateOfBirth = null;
        

            // Act
            bool result = Utils.IsOver22(dateOfBirth);

            // Assert
            Assert.IsFalse(result);
        }
    }
}