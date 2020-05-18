using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }
 
        [Test]
        public void ConstructorShouldThrowWithManyelements()
        {
            //Arrange
            Database database;
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                database = new Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21);
            });

        }
        [Test]
        public void DataBaseConstructorWorkedCorectly()
        {
            //Arrange 
            var database = new Database(1, 2, 3);
            //Act
            int expectedCount = 3;
            int actualCount = database.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void DataBaseCannotAddMoreElements()
        {
            //Arrange
            var database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act 
                database.Add(17);
            });
        }

        [Test]
        public void RemoveMethodCannotWorkWithEmptyDatabase()
        {
            //Arrange
            var database = new Database();
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                database.Remove();
            });
        }

        [Test]
        public void FetchHaveToCallBackTheSameElementsOfDataBaseArrays()
        {
            //Arrange
            var database = new Database(1,2,3);

            //Act
            var expected = new int[] {1, 2, 3};
            var actual = database.Fetch();
            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }
    }
}