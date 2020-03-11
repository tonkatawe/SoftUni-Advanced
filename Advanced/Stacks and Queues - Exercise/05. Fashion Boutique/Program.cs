using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var capacityOfRack = int.Parse(Console.ReadLine());
            var numberOfRuck = 1;
            var sum = 0;
            var stack = new Stack<int>(clothes);
            while (stack.Count >0)
            {
                sum += stack.Peek();
                if (sum<= capacityOfRack)
                {
                    stack.Pop();
                }
                else
                {
                    numberOfRuck++;
                    sum = 0;
                }
            }

            Console.WriteLine(numberOfRuck);
        }
    }
}
