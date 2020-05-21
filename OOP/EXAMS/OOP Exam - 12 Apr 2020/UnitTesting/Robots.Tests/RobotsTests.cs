using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void TestIfRobotConstructorWorkCorrectly()
        {
            //Arrange
            var expectedName = "pesho";
            var maximumBattery = 10;
            var battery = maximumBattery;
            //Act
            var robot = new Robot(expectedName, maximumBattery);
            var actualName = robot.Name;
            var actualMaximumBattery = robot.MaximumBattery;
            var actualBattery = robot.Battery;
            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(maximumBattery, actualMaximumBattery);
            Assert.AreEqual(battery, actualBattery);
        }

        [Test]
        public void TestIfRobotManagerConstructorWorkCorrectly()
        {
            //Arrange
            var expectedCapacity = 10;
            //Act
            var robotManager = new RobotManager(expectedCapacity);
            var actualCapacity = robotManager.Capacity;
            //Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void TryMakeRobotWithNegativeCapacity()
        {
            //Arrange
            var capacity = -10;
            //Assert & Act
            Assert.Throws<ArgumentException>(() =>
            {
                var robotManager = new RobotManager(capacity);
            });
        }

        [Test]
        public void WhenInstanceRoborItShouldNotNull()
        {
            //Arrange
            var capacity = 10;
            //Act
            var robotManager = new RobotManager(capacity);
            //Assert 
            Assert.That(robotManager.Count, Has.No.Null);
        }

        [Test]
        public void WhenTryToAddRobotWihtExistNameShouldBeThrows()
        {
            //Arrange
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(2);
            robotManager.Add(robot);
            //Assert&Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Pesho", 15));

            });
        }
        [Test]
        public void WhenTryToAddRobotWhenCapacityIsFull()
        {
            //Arrange
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            //Assert&Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Gosho", 15));

            });
        }
        [Test]
        public void AddRobotShouldBeWorkNormal()
        {
            //Arrange
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(1);
            var expectedCount = 1;
            //Act
            robotManager.Add(robot);
            var actualCount = robotManager.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void RemoveRobotShouldBeWorkNormal()
        {
            //Arrange
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            var expectedCount = 0;
            //Act
            robotManager.Remove("Pesho");
            var actualCount = robotManager.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void RobotShouldNotWorkIfItNoExist()
        {
            //Arrange
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            //Assert&Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Spas","kofraj", 5);

            });
        }
        [Test]
        public void RobotShouldNotWorkWithFewerBattery()
        {
            //Arrange
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            //Assert&Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Pesho", "kofraj", 15);

            });
        }
        [Test]
        public void RobotShouldNotChargeIfItNoExist()
        {
            //Arrange
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            //Assert&Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Spas");

            });
        }
        [Test]
        public void BatteryShouldDecreaseWhenRobotWorkCorrectly()
        {
            //Arrange
            var robot = new Robot("Pesho", 20);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            var expectedBattery = 5;
            //Act
            robotManager.Work("Pesho", "kofraj", 15);
            var actualBatter = robot.Battery;
            //Assert
            Assert.AreEqual(expectedBattery,actualBatter);
        }
        [Test]
        public void BatteryShouldIncreaseWhenRobotCharge()
        {
            //Arrange
            var robot = new Robot("Pesho", 20);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            robotManager.Work("Pesho", "kofraj", 15);
            var expectedBattery = 20;
            //Act
            robotManager.Charge("Pesho");
            var actualBatter = robot.Battery;
            //Assert
            Assert.AreEqual(expectedBattery, actualBatter);
        }


        [Test]
        public void WhenTryRemoveNulRobotShouldThrows()
        {
            //Arrange 
            Robot robot = new Robot("Pesho", 10);

            //Assert & Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                var robotManager = new RobotManager(10);
                robotManager.Remove("Spas");
            });
        }
    }
}
