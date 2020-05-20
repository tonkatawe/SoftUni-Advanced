
using System.Collections.Generic;

namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        //todo 75/100 in judge I have to improve my nunit testing skills :)
        [Test]
        public void TestIfConstructorWorkCorrectly()
        {
            //Arrange
            var expectedName = "Gosho";
            var expecterdCapacity = 10;
            //Act
            var aquarium = new Aquarium(expectedName, expecterdCapacity);
            var actualName = aquarium.Name;
            var actualCapacity = aquarium.Capacity;
            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expecterdCapacity, actualCapacity);
            Assert.That(aquarium.Count, Has.No.Null);
        }
        [Test]
        public void TestIfReportMethodWorkCorectly()
        {
            //Arrange
            var name = "Gosho";
            var capacity = 10;
            var fish = new Fish("Pesho");
            var expetedMessage = "Fish available at Gosho: Pesho";
            var aquarium = new Aquarium(name, capacity);
            //Act
            aquarium.Report();
            var actualmessage = $"Fish available at {aquarium.Name}: {fish.Name}";
           
            //Assert
            Assert.AreEqual(expetedMessage, actualmessage);
            
        }

        [Test]
        public void WhenTryingToRemoveNoExistFishShouldBeThrow()
        {
            //Arrange
            Fish removeFish = new Fish("Pesho");
            var aquarium = new Aquarium("gosho",10);
            //Assert & Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(removeFish);
                aquarium.RemoveFish("spas");
            });
        }
        [Test]
        public void WhenRemoveExistFishShouldBeWorkCorrectly()
        {
            //Arrange
            Fish removeFish = new Fish("Pesho");
            var aquarium = new Aquarium("gosho", 10);
            var expectetAquariumCount = 0;
            //Act
            aquarium.Add(removeFish);
            aquarium.RemoveFish("Pesho");
            var actualAquariumCount = aquarium.Count;
            //Assert
            Assert.AreEqual(expectetAquariumCount, actualAquariumCount);

        }
        [Test]
        public void WhenTryingToSellNoExistFishShouldBeThrow()
        {
            //Arrange
            Fish removeFish = new Fish("Pesho");
            var aquarium = new Aquarium("gosho", 10);
            //Assert & Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(removeFish);
                aquarium.SellFish("spas");
            });
        }

        [Test]
        public void WhenSellExistFishShouldBeThrow()
        {
            //Arrange
            Fish removeFish = new Fish("Pesho");
            var aquarium = new Aquarium("gosho", 10);
            var expectedFish = false;
            //Act
            aquarium.Add(removeFish);
            aquarium.SellFish("Pesho");
            var actualFish = removeFish.Available;
            //Assert
            Assert.AreEqual(expectedFish, actualFish);
        }

        [Test]
        public void TestIfConstructorWorkCorrectlyWithCount()
        {
            //Arrange
            var expectedName = "Gosho";
            var expecterdCapacity = 10;
            //Act
            var aquarium = new Aquarium(expectedName, expecterdCapacity);
            //Assert
            Assert.That(aquarium.Count, Has.No.Null);
        }

        [Test]
        public void WithFullCapacityShouldBeThrow()
        {
            //Arrange
            var name = "gosho";
            var capacity = 1;
            var aquarium = new Aquarium(name, capacity);
            var fishName = "pesho";
            var fish = new Fish(fishName);
            aquarium.Add(fish);
            //Assert & Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("Chocho"));
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestLikeEmptyOrNullName(string name)
        {
            //Arrange
            var cappacity = 10;
            //Assert & Act
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium(name, cappacity);
            });
        }
        [Test]

        public void TestLikeNegativeCapacity()
        {
            //Arrange
            var name = "Gosho";
            var cappacity = -10;
            //Assert & Act
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium(name, cappacity);
            });
        }
    }
}
