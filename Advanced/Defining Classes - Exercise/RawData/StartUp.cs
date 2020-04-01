using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); //read the number of cars I have
            var cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = input[0];
                var engineSpeed = int.Parse(input[1]);
                var enginePower = int.Parse(input[2]);
                var cargoWeight = int.Parse(input[3]);
                var cargoType = input[4];
                var tire1Pressure = double.Parse(input[5]);
                var tire1Age = int.Parse(input[6]);
                var tire2Pressure = double.Parse(input[7]);
                var tire2Age = int.Parse(input[8]);
                var tire3Pressure = double.Parse(input[9]);
                var tire3Age = int.Parse(input[10]);
                var tire4Pressure = double.Parse(input[11]);
                var tire4Age = int.Parse(input[12]);
                var currentCargo = new Cargo(cargoWeight, cargoType);
                var currentEngine = new Engine(engineSpeed, enginePower);
                var currentTires = new Tire[4]
                {
                    new Tire(tire1Age,tire1Pressure),
                    new Tire(tire2Age,tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure),
                };
                var currentCar = new Car(model, currentEngine, currentCargo, currentTires);
                cars.Add(currentCar);
            }

            var command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.CargoType == "fragile"))
                {

                    foreach (var tire in car.Tires.Where(x => x.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                        break;
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(x => x.Cargo.CargoType == "flamable").Where(x => x.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
