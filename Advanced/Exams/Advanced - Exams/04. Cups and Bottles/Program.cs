using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = ParseArrayFromConsole(); // read cups, it should be queue FIFO
            var m = ParseArrayFromConsole(); // read bottles, it should be stack LIFO
            var cups = new Queue<int>(n);
            var bottles = new Stack<int>(m);
            var wasteWater = 0;

            while (cups.Any() && bottles.Any())
            {
                var currentCup = cups.Peek();
                var currentBottle = bottles.Peek();

                if (currentBottle >= currentCup)
                {
                    wasteWater += bottles.Pop() - cups.Dequeue();
                }

                else if (currentBottle < currentCup)
                {
                    while (currentCup > 0)
                    {
                        var restCup = currentCup - currentBottle;
                        currentCup -= currentBottle;

                        var currentArray = new int[cups.Count + 1];
                        currentArray[0] = restCup;
                        for (int i = 1; i < currentArray.Length; i++)
                        {
                            currentArray[i] = cups.Dequeue();
                        }
                        cups = new Queue<int>(currentArray);
                        currentBottle = bottles.Peek();
                        currentCup -= currentBottle;
                    }
                }

            }

            if (cups.Any())
            {

                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wasteWater}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wasteWater}");
            }
        }

        private static int[] ParseArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
