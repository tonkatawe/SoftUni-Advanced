using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>(); //here put colors, <items, count>
            var n = int.Parse(Console.ReadLine()); //number of commands
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var color = tokens[0];
                var items = tokens[1].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var item in items)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }

                    wardrobe[color][item]++;
                }

            }

            var lookedClothes = Console.ReadLine().Split(' ');
            var paint = lookedClothes[0];
            var type = lookedClothes[1];
            foreach (var kvp in wardrobe)
            {
                var colour = kvp.Key;
                var typesAndCounts = kvp.Value;
                Console.WriteLine($"{colour} clothes:");
                foreach (var types in typesAndCounts)
                {
                    if (colour.Contains(paint) && types.Key == type)
                    {
                        Console.WriteLine($"* {types.Key} - {types.Value} (found!)");
                    }
                    else
                    {

                        Console.WriteLine($"* {types.Key} - {types.Value}");
                    }
                }
            }
        }
    }
}
