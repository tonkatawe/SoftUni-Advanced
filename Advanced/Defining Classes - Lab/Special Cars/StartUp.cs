using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    //80/100 have to check :)
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tiresData = new List<Tire[]>();
            var enginesData = new List<Engine>();
            var carsData = new List<Car>();
            //read tires with loop below
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }

                var tokens = input.Split()
                    .ToArray();

                var currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tokens[0]), double.Parse(tokens[1])),
                    new Tire(int.Parse(tokens[2]), double.Parse(tokens[3])),
                    new Tire(int.Parse(tokens[4]), double.Parse(tokens[5])),
                    new Tire(int.Parse(tokens[6]), double.Parse(tokens[7])),
                };
                tiresData.Add(currentTires);

            }
            //read Engines with loop below
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }

                var tokens = input
                    .Split()
                    .ToArray();
                var horsePower = int.Parse(tokens[0]);
                var cubicCapacity = double.Parse(tokens[1]);
                var currentEngine = new Engine(horsePower, cubicCapacity);
                enginesData.Add(currentEngine);

            }
            //read cars with loop below
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;

                }

                var tokens = input.Split();
                var make = tokens[0];
                var model = tokens[1];
                var year = int.Parse(tokens[2]);
                var fuelQuantity = double.Parse(tokens[3]);
                var fuelConsumption = double.Parse(tokens[4]);
                var engineIndex = int.Parse(tokens[5]);
                var tiresIndex = int.Parse(tokens[6]);
                var currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, enginesData[engineIndex], tiresData[tiresIndex]);
                carsData.Add(currentCar);
            }

            bool pressure = false;
            foreach (var car in carsData)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 300)
                {
                    var sumPressure = 0d;
                    foreach (var tire in car.Tires)
                    {
                        sumPressure += tire.Pressure;
                    }

                    if (sumPressure >= 9 && sumPressure <= 10)
                    {
                        pressure = true;
                    }

                    var neededFuel = car.FuelConsumption * 20 / 100;
                    if (pressure)
                    {

                        Console.WriteLine($"Make: {car.Make}");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Year: {car.Year}");
                        Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                        Console.WriteLine($"FuelQuantity: {car.FuelQuantity - neededFuel}");
                    }
                }
            }
        }
    }
}
