using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engines = new List<Engine>();
            var cars = new Queue<Car>();
            var n = int.Parse(Console.ReadLine()); //read all engines
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = input[0];
                var power = int.Parse(input[1]);
                var displacement = int.Parse(input[2]);//use try pass 
                var currentEngine = new Engine(model, power, displacement);
                if (input.Length == 4)
                {
                    var eFficiency = input[3];
                    currentEngine.Efficiency = eFficiency;
                }
                engines.Add(currentEngine);

            }

            var m = int.Parse(Console.ReadLine()); //read all cars
            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var engine = new Engine(input[1]);
                var currentCar = new Car(model, engine);
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

                if (input.Length == 4)
                {
                    var weight = int.Parse(input[2]);
                    var color = input[3];
                    currentCar.Weight = weight;
                    currentCar.Color = color;
                }

            }
        }
    }
}
