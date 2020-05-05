using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01._Sport_Cards
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                var tokens = command.Split();
                if (tokens[0] == "check")
                {
                    if (data.ContainsKey(tokens[1]))
                    {
                        Console.WriteLine($"{tokens[1]} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[1]} is not available!");
                    }
                    continue;
                }

                var card = tokens[0];
                var sport = tokens[2];
                var price = double.Parse(tokens[4]);
                if (!data.ContainsKey(card))
                {     
                    data[card] = new Dictionary<string, double>();
                }

                if (!data[card].ContainsKey(sport) || data[card].ContainsKey(sport))
                {
                    data[card][sport] = price;
                }
            }

            foreach (var card in data.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{card.Key}:");
                foreach (var sport in card.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"  -{sport.Key} - {sport.Value:F2}");
                }

            }
        }
    }
}
