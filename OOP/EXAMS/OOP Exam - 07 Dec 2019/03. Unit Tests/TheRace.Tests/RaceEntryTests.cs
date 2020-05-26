using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfRaceEntryConstructorWorkCorrectly()
        {
            //Arrange
            var raceEntry = new RaceEntry();
            //Assert & Act
            Assert.That(raceEntry, Has.No.Null);
        }
        [Test]
        public void CheckCounterOfRaceEntry()
        {
            //Arrange
            var raceEntry = new RaceEntry();
            var unitMotorcycle = new UnitMotorcycle("yamaha", 100, 150);
            var expectedCount = 1;
            //Act
            var unitRider = new UnitRider("Pesho", unitMotorcycle);
            raceEntry.AddRider(unitRider);
            var actualCount = raceEntry.Counter;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TryAddRiderLikeNull()
        {
            //Arrange
            var raceEntry = new RaceEntry();

            //Assert & Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(null);

            });
        }
        [Test]
        public void TryAddRiderLikeExistRacer()
        {
            //Arrange
            var raceEntry = new RaceEntry();
            var unitMotorcycle = new UnitMotorcycle("yamaha", 100, 150);

            var unitRider = new UnitRider("Pesho", unitMotorcycle);
            raceEntry.AddRider(unitRider);
            //Assert & Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(unitRider);

            });
        }

        [Test]
        public void CalculateWithFewerRacerecShouldThrowError()
        {
            //Arrange
            var raceEntry = new RaceEntry();
            var unitMotorcycle = new UnitMotorcycle("yamaha", 100, 150);

            var unitRider = new UnitRider("Pesho", unitMotorcycle);
            raceEntry.AddRider(unitRider);
            //Assert & Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }
        [Test]
        public void CalculateWithTwoRacerecr()
        {
            //Arrange
            var raceEntry = new RaceEntry();
            var racerOne = new UnitMotorcycle("yamaha", 150, 458);
            var racerTwo = new UnitMotorcycle("yamaha", 250, 375);

            var unitRiderOne = new UnitRider("Pesho", racerOne);
            var unitRiderTwo = new UnitRider("Gosho", racerTwo);
            var expectedResult = 200;
            //Act
            raceEntry.AddRider(unitRiderOne);
            raceEntry.AddRider(unitRiderTwo);
            var actualResult = raceEntry.CalculateAverageHorsePower();


            //Assert 
            Assert.AreEqual(expectedResult,actualResult);
        }
    }
}