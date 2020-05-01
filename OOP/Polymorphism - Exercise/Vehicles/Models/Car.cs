using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicles
    {
        private const double airConditionNeeds = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditionNeeds;
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount);
        }
    }
}
