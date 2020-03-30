using System;
using System.Collections.Generic;
using System.Linq;

namespace Special_Cars
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }

                var tokens = input.Split();
                var year = int.Parse(tokens[0]);
                var pressure = double.Parse(tokens[1]);
                var tiresData = new List<Tire>()
                {
                    new Tire(int.Parse(tokens[0]), double.Parse(tokens[1])),
                    new Tire(int.Parse(tokens[2]), double.Parse(tokens[3])),
                    new Tire(int.Parse(tokens[4]), double.Parse(tokens[5])),
                    new Tire(int.Parse(tokens[6]), double.Parse(tokens[7])),
                };
                Console.WriteLine(tiresData.Sum(pressure));
                tiresData.Sum()
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;

                }
            }
        }
    }
}
