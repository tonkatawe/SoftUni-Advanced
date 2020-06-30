using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new SortedDictionary<string, int>()
            {
                {"Datura Bombs",0},
                {"Cherry Bombs",0},
                {"Smoke Decoy Bombs",0}
            };
            var n = ReadArrFromConsole();// bomb effects
            var m = ReadArrFromConsole(); // bomb casing

            var effects = new Queue<int>(n);
            var casing = new Stack<int>(m);

            while (effects.Any() && casing.Any())
            {
                var currentEffects = effects.Peek();
                var currentCasing = casing.Peek();
                var sum = currentCasing + currentEffects;
                if ((data["Smoke Decoy Bombs"] >= 3 && data["Cherry Bombs"] >= 3 && data["Datura Bombs"] >= 3))
                {
                    break;

                }
                if (sum == 40 || sum == 60 || sum == 120)
                {
                    if (sum == 40)
                    {
                        data["Datura Bombs"]++;

                    }
                    else if (sum == 60)
                    {
                        data["Cherry Bombs"]++;
                    }
                    else if (sum == 120)
                    {
                        data["Smoke Decoy Bombs"]++;
                    }

                    casing.Pop();
                    effects.Dequeue();
                }
                else
                {
                    casing.Push(casing.Pop() - 5);
                }
            }

            if (!effects.Any() || !casing.Any() && (data["Smoke Decoy Bombs"] < 3 || data["Cherry Bombs"] < 3 || data["Datura Bombs"] < 3))
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
                if (effects.Any())
                {
                    Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
                }
                else
                {
                    Console.WriteLine($"Bomb Effects: empty");
                }

                if (casing.Any())
                {
                    Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
                }
                else
                {

                    Console.WriteLine($"Bomb Casings: empty");
                }
                foreach (var bomb in data)
                {
                    Console.WriteLine($"{bomb.Key}: {bomb.Value}");
                }
            }
            else if ((data["Smoke Decoy Bombs"] >= 3 && data["Cherry Bombs"] >= 3 && data["Datura Bombs"] >= 3))
            {

                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                if (effects.Any())
                {
                    Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
                }
                else
                {
                    Console.WriteLine($"Bomb Effects: empty");
                }

                if (casing.Any())
                {
                    Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
                }
                else
                {

                    Console.WriteLine($"Bomb Casings: empty");
                }
                foreach (var bomb in data)
                {
                    Console.WriteLine($"{bomb.Key}: {bomb.Value}");
                }
            }

        }

        private static int[] ReadArrFromConsole()
        {
            return Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
        }
    }
}
