using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());//read number of cars
            var cars = new HashSet<Car>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumptionPerKilometer = double.Parse(input[2]);
                var currentCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(currentCar);


            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split();
                var model = tokens[1];
                var amountOfKm = double.Parse(tokens[2]);
                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.CarDriveDistance(amountOfKm);
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }
    }
}
