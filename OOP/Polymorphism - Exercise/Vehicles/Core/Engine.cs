using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            var readCar = Console.ReadLine().Split();
            var car = new Car(double.Parse(readCar[1]), double.Parse(readCar[2]), double.Parse(readCar[3]));
            var readTruck = Console.ReadLine().Split();
            var truck = new Truck(double.Parse(readTruck[1]), double.Parse(readTruck[2]), double.Parse(readTruck[3]));
            var readBus = Console.ReadLine().Split();
            var bus = new Bus(double.Parse(readBus[1]), double.Parse(readBus[2]), double.Parse(readBus[3]));

            var n = int.Parse(Console.ReadLine()); //read number of commands
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();
                var command = input[0];
                var vehicleType = input[1];
                var value = double.Parse(input[2]);
                try
                {

                    if (command == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(value));

                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(value));
                        }
                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(value));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        Console.WriteLine(bus.DriveEmptyBus(value));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
