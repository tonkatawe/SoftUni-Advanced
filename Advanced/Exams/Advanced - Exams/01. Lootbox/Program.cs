using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            // make first input for first loot box and here use FIFO - Queue
            var n = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            // make second input for second loot box and here use LIFO - Stack
            var m = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstBox = new Queue<int>(n);
            var secondBox = new Stack<int>(m);
            var claimedItems = 0;
            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                var currentSum = firstBox.Peek() + secondBox.Peek();
                if (currentSum % 2 == 0)
                {
                    claimedItems += currentSum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
