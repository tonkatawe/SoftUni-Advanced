using NUnit.Framework;

namespace Presents.Tests
{
    using System;
    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void PresentConstructorWorkCorrectly()
        {
            //Arrange
            var expectedName = "Pesho";
            var expectedMagic = 10d;
            //Act
            var present = new Present(expectedName, expectedMagic);
            var actualName = present.Name;
            var actualMagic = present.Magic;
            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedMagic,actualMagic);


        }

        [Test]
        public void BagConstructorShouldCreateListPresent()
        {
            //Arrange
            
            //Act
            var bag = new Bag();
            
            //Assert
            Assert.That(bag, Has.No.Null);
        }

        [Test]
        public void ShouldBeThrowExeptionTryingToCreatePresentLikeNull()
        {
            //Arrange
            Present present = null;
            var bag = new Bag();
            //Assert & Act
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });
        }
        [Test]
        public void ShouldBeThrowExeptionTryingToCreateExistPresent()
        {
            //Arrange
            Present present = new Present("gosho", 10);
            var bag = new Bag();
            //Assert & Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
                bag.Create(present);
            });
        }
        [Test]
        public void ShouldBeGetresent()
        {
            //Arrange
            Present present = new Present("gosho", 10);
            var bag = new Bag();
            //Act
            bag.Create(present);
            //Assert & Act
            Assert.That(bag.GetPresent("gosho") == present);
        }
        [Test]
        public void ShouldReturnTrueWhenRemovePresent()
        {
            //Arrange
            Present present = new Present("gosho", 10);
            var bag = new Bag();
            bag.Create(present);
            //Assert & Act
            Assert.IsTrue(bag.Remove(present));
        }
        [Test]
        public void ReturnPresentWithLeastMagic()
        {
            //Arrange
            Present presentOne = new Present("gosho", 10);
            Present presentTwo = new Present("pesho",20);
            var bag = new Bag();
            bag.Create(presentOne);
            bag.Create(presentTwo);
            //Act
            var actualPresent = bag.GetPresentWithLeastMagic();
            //Assert
            Assert.AreEqual(presentOne, actualPresent);
        }
        [Test]
        public void ReturnIReadOnlyCollection()
        {
            //Arrange
            Present presentOne = new Present("gosho", 10);
            Present presentTwo = new Present("pesho", 20);
            var bag = new Bag();
            bag.Create(presentOne);
            bag.Create(presentTwo);
            var expectedCount = 2;
            //Act
            var actualCount = bag.GetPresents().Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
