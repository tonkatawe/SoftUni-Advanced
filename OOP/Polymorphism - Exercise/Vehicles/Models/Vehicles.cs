using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicles
    {
        private double fuelConsumption;
        private double fuelQuantity;
        private double tankCapacity;
        public Vehicles(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.tankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                this.fuelQuantity = value; ;
            }
        }
        protected double FuelConsumption
        {
            get => this.fuelConsumption;
            set
            {
                this.fuelConsumption = value;
            }
        }
        protected double TankCapacity { get; set; }

        public string Drive(double distance)
        {
            var neededFuel = distance * this.FuelConsumption;
            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + fuelAmount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }
             this.FuelQuantity += fuelAmount;
        }
    }
}
