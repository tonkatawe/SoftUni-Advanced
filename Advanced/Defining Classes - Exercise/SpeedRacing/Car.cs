using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double traveledDistance;

        public Car()
        {
            this.TraveledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        : this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                this.fuelAmount = value;
            }
        }

        public double FuelConsumptionPerKilometer
        {
            get
            {
                return this.fuelConsumptionPerKilometer;
            }
            set
            {
                this.fuelConsumptionPerKilometer = value;
            }
        }

        public double TraveledDistance
        {
            get
            {
                return this.traveledDistance;
            }
            set
            {
                this.traveledDistance = value;
            }
        }

        public void CarDriveDistance(double amountOfKm)
        {
            var neededFuel = amountOfKm * this.FuelConsumptionPerKilometer;
            if (neededFuel <= this.FuelAmount)
            {
                this.fuelAmount -= neededFuel;
                this.traveledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
