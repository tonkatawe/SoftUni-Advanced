using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _04._Travel_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                var tokens = command.Split(" > ", StringSplitOptions.RemoveEmptyEntries);
                var country = tokens[0];
                var town = tokens[1];
                var cost = int.Parse(tokens[2]);
                if (!data.ContainsKey(country))
                {
                    data[country] = new Dictionary<string, int>();
                }

                if (!data[country].ContainsKey(town))
                {
                    data[country][town] = cost;
                }
                if (data[country].ContainsKey(town) && data[country][town] > cost)
                {
                    data[country][town] = cost;
                }
            }

            foreach (var country in data.OrderBy(x=> x.Key))
            {
                Console.Write($"{country.Key} -> ");
                foreach (var town in country.Value.OrderBy(x=>x.Value))
                {
                    Console.Write($"{town.Key} -> {town.Value} ");
                }

                Console.WriteLine();
            }
        }
    }
}
