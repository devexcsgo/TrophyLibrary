using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrophyLibrary.Tests
{
    [TestClass()]
    public class ThophyRepositoryTests
    {
        [TestMethod()]
        public void ThophyRepositoryTest()
        {
            var repository = new ThophyRepository();
            var trophies = repository.Get().ToList();
            Assert.AreEqual(13, trophies.Count);
        }

        [TestMethod()]
        public void GetTest()
        {
            var repository = new ThophyRepository();

            var allTrophies = repository.Get().ToList();
            Assert.AreEqual(13, allTrophies.Count);

            var yearTrophies = repository.Get(year: 2018).ToList();
            Assert.AreEqual(1, yearTrophies.Count);
            Assert.AreEqual(2018, yearTrophies[0].Year);

            var competitionTrophies = repository.Get(competitionName: "World Cup").ToList();
            Assert.AreEqual(13, competitionTrophies.Count);

            var orderedByYear = repository.Get(orderBy: "year").ToList();
            Assert.IsTrue(orderedByYear.SequenceEqual(orderedByYear.OrderBy(t => t.Year)));

            var orderedByCompetition = repository.Get(orderBy: "competition").ToList();
            Assert.IsTrue(orderedByCompetition.SequenceEqual(orderedByCompetition.OrderBy(t => t.Competition)));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var repository = new ThophyRepository();

            var trophy = repository.GetById(1);
            Assert.IsNotNull(trophy);
            Assert.AreEqual(1, trophy.Id);

            var nonExistentTrophy = repository.GetById(999);
            Assert.IsNull(nonExistentTrophy);
        }

        [TestMethod()]
        public void AddTest()
        {
            var repository = new ThophyRepository();
            var newTrophy = new Trophy { Competition = "Euro Cup", Year = 2023 };

            var addedTrophy = repository.Add(newTrophy);
            Assert.IsNotNull(addedTrophy);
            Assert.AreEqual(1, addedTrophy.Id);
            Assert.AreEqual("Euro Cup", addedTrophy.Competition);
            Assert.AreEqual(2023, addedTrophy.Year);

            var allTrophies = repository.Get().ToList();
            Assert.AreEqual(14, allTrophies.Count);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var repository = new ThophyRepository();

            var removedTrophy = repository.Remove(1);
            Assert.IsNotNull(removedTrophy);
            Assert.AreEqual(1, removedTrophy.Id);

            var nonExistentTrophy = repository.Remove(999);
            Assert.IsNull(nonExistentTrophy);

            var allTrophies = repository.Get().ToList();
            Assert.AreEqual(12, allTrophies.Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var repository = new ThophyRepository();
            var updatedTrophy = new Trophy { Competition = "Updated Competition", Year = 2023 };

            var result = repository.Update(1, updatedTrophy);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Updated Competition", result.Competition);
            Assert.AreEqual(2023, result.Year);

            var nonExistentUpdate = repository.Update(999, updatedTrophy);
            Assert.IsNull(nonExistentUpdate);
        }
    }
}
