using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split().Select(int.Parse).ToArray(); //input for cup's capacity
            var j = Console.ReadLine().Split().Select(int.Parse).ToArray(); //input for filled bottle
            var cupsCapacity = new Queue<int>(n); //cups capacity use FIFO following instruction
            var filledBottles = new Stack<int>(j); //Filled bottle use LIFO following instruction

            var wasteWater = 0;
            while (true)
            {
                if (cupsCapacity.Any() && filledBottles.Any())
                {
                    if (filledBottles.Peek() >= cupsCapacity.Peek())
                    {
                        wasteWater += filledBottles.Pop() - cupsCapacity.Dequeue();
                    }
                    else if (cupsCapacity.Peek() > filledBottles.Peek())
                    {
                        var currentCup = cupsCapacity.Peek();
                        while (currentCup > 0)
                        {
                            currentCup -= filledBottles.Pop();
                        }

                        wasteWater += Math.Abs(currentCup);

                        cupsCapacity.Dequeue();
                    }
                }

                if (!cupsCapacity.Any() && filledBottles.Any())
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", filledBottles)}");
                    Console.WriteLine($"Wasted litters of water: {wasteWater}");
                    break;
                }
                else if (cupsCapacity.Any() && !filledBottles.Any())
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
                    Console.WriteLine($"Wasted litters of water: {wasteWater}");
                    break;
                }

            }
        }
    }
}
