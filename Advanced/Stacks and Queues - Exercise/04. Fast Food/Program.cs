using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodQuantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(orders);
            var sum = 0;
            Console.WriteLine(queue.Max());
            while (queue.Count > 0)
            {
                sum += queue.Peek();
                if (sum <= foodQuantity)
                {
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                    
                }
            }

            Console.WriteLine("Orders complete");

        }
    }
}
