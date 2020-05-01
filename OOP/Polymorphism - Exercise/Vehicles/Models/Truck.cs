using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicles
    {
        private const double airConditionNeeds = 1.6;
        private const double refuelingCoefficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditionNeeds;
        }


        public override void Refuel(double fuelAmount)
        {
           
             base.Refuel(fuelAmount);
            this.FuelQuantity -= (1 - refuelingCoefficient) * fuelAmount;
        }
    }
}
