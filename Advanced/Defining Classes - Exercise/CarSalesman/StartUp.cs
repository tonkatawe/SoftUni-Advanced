using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engines = new HashSet<Engine>();
            var cars = new List<Car>();
            var n = int.Parse(Console.ReadLine()); //read all engines
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = input[0];
                var power = int.Parse(input[1]);
                var currentEngine = new Engine(model, power);
                if (input.Length == 3)
                {
                    var succes = int.TryParse(input[2], out int result);

                    if (succes)
                    {
                        var displacement = int.Parse(input[2]);
                        currentEngine.Displacement = displacement;
                    }
                    else
                    {
                        var efficiency = input[2];
                        currentEngine.Efficiency = efficiency;
                    }
                }
                else if (input.Length == 4)
                {
                    var displacement = int.Parse(input[2]);
                    var efficiency = input[3];
                    currentEngine.Displacement = displacement;
                    currentEngine.Efficiency = efficiency;
                }
                engines.Add(currentEngine);
            }

            var m = int.Parse(Console.ReadLine()); //read all cars
            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var currentCar = new Car(model, engines.First(x => x.Model == input[1]));
                cars.Add(currentCar);
                if (input.Length == 3)
                {
                    var succes = int.TryParse(input[2], out int result);
                    if (succes)
                    {
                        var weight = int.Parse(input[2]);
                        currentCar.Weight = weight;
                    }
                    else
                    {
                        var color = input[2];
                        currentCar.Color = color;
                    }

                }

                else if (input.Length == 4)
                {
                    var weight = int.Parse(input[2]);
                    var color = input[3];
                    currentCar.Weight = weight;
                    currentCar.Color = color;
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }


        }
    }
}
