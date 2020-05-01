using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicles
    {
        private const double airConditionNeeds = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditionNeeds;
        }

        public string DriveEmptyBus(double distance)
        {
            this.FuelConsumption -= airConditionNeeds;
            return Drive(distance);
        }


        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount);
        }
    }
}
