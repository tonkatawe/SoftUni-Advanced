using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); //it is maxBound
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var result = new List<int>();
            for (int i = 1; i <= n; i++) // start 1...n
            {
                var isDivde = true;
                foreach (var digit in numbers)
                {
                    if (i % digit != 0)
                    {
                        isDivde = false;
                        break;
                    }

                }

                if (!isDivde)
                {

                    continue;

                }
                result.Add(i);

            }
            Console.WriteLine(string.Join(' ', result));

        }
    }
}
