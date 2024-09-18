using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLibrary;
using System;

namespace TrophyLibrary.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var trophy = new Trophy { Id = 1, Competition = "World Cup", Year = 2022 };

            // Act
            var result = trophy.ToString();

            // Assert
            Assert.AreEqual("1 World Cup 2022", result);
        }

        [TestMethod()]
        public void ValidateYearTest()
        {
            // Arrange
            var trophy = new Trophy { Id = 1, Competition = "World Cup", Year = 2022 };

            // Act & Assert
            trophy.ValidateYear(); // Should not throw

            trophy.Year = 1969;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.ValidateYear());

            trophy.Year = 2024;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.ValidateYear());
        }

        [TestMethod()]
        public void ValidateCompetitionTest()
        {
            // Arrange
            var trophy = new Trophy { Id = 1, Competition = "World Cup", Year = 2022 };

            // Act & Assert
            trophy.ValidateCompetition(); // Should not throw

            trophy.Competition = null;
            Assert.ThrowsException<ArgumentNullException>(() => trophy.ValidateCompetition());

            trophy.Competition = "WC";
            Assert.ThrowsException<ArgumentException>(() => trophy.ValidateCompetition());
        }
    }
}
