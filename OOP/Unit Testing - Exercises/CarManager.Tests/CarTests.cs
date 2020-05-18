using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorkCorrectly()
        {
            //Arrange
            string expectedMake = "VW";
            string expectedModel = "Golf";
            double expectedFuelConsumption = 10;
            double expectedFuelCapacity = 50;
            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);
            //Act
            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumption = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;

            //Assert
            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void TestWithLikeEmptyMake()
        {
            //Arrange
            string make = "";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }).Message.Equals("Make cannot be null or empty!");
        }
        [Test]
        public void TestWithLikeNullMake()
        {
            //Arrange
            string make = null;
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }).Message.Equals("Make cannot be null or empty!");
        }
        [Test]
        public void TestWithLikeNullModel()
        {
            //Arrange
            string make = "VW";
            string model = null;
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }).Message.Equals("Model cannot be null or empty!");
        }
        [Test]
        public void TestWithLikeEmptyModel()
        {
            //Arrange
            string make = "VW";
            string model = "";
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }).Message.Equals("Model cannot be null or empty!");
        }
        [Test]
        public void TestWithLikeZeroFuelConsumption()
        {
            //Arrange
            string make = "VW";
            string model = "Passat";
            double fuelConsumption = 0;
            double fuelCapacity = 50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }).Message.Equals("Fuel consumption cannot be zero or negative!");
        }
        [Test]
        public void TestWithLikeNegativeFuelConsumption()
        {
            //Arrange
            string make = "VW";
            string model = "Passat";
            double fuelConsumption = -10;
            double fuelCapacity = 50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }).Message.Equals("Fuel consumption cannot be zero or negative!");
        }
        [Test]
        public void TestWithLikeNegativeFuelCapacity()
        {
            //Arrange
            string make = "VW";
            string model = "Passat";
            double fuelConsumption = 10;
            double fuelCapacity = -50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }).Message.Equals("Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void TestWithLikeZeroFuelCapacity()
        {
            //Arrange
            string make = "VW";
            string model = "Passat";
            double fuelConsumption = 10;
            double fuelCapacity = 0;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }).Message.Equals("Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void TestWitshLikeNegativeFuelAmount()
        {
            //Arrange
            var make = "VW";
            var model = "Passat";
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            double fuelAmount = -5;
            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelAmount);
            }).Message.Equals("Fuel amount cannot be zero or negative!");

        }
  
        [Test]
        public void TestWitshLikeZeroFuelAmount()
        {
            //Arrange
            var make = "VW";
            var model = "Passat";
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            double fuelAmount = 0;
            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelAmount);
            }).Message.Equals("Fuel amount cannot be zero or negative!");

        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfNotEnoughFuel()
        {
            //Arrange
            var make = "VW";
            var model = "Passat";
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                car.Drive(1000);
            }).Message.Equals("You don't have enough fuel to drive!");

        }

        [Test]
        public void TestRefuelWorkCorrectly()
        {
            //Arrange
            var make = "VW";
            var model = "Passat";
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            double fuelTorefual = 60;
            double expectedFuelAmount = car.FuelCapacity;
            //Act
            car.Refuel(fuelTorefual);
            double actualFuelAmount = car.FuelAmount;
            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void TestDriveWorkCorrectly()
        {
            //Arrange
            var make = "VW";
            var model = "Passat";
            double fuelConsumption = 10;
            double fuelCapacity = 50;
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            double fuelTorefual = 60;
            double expectedFuelAmount = 40;
            //Act
            car.Refuel(fuelTorefual);
            double actualFuelAmount = car.FuelAmount-10;
            car.Drive(100);
            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }


    }
}