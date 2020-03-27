using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;
            var bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var minBound = bounds[0];
            var maxBound = bounds[1];
            var result = new List<int>();
            for (int i = minBound; i <= maxBound; i++)
            {
                result.Add(i);
            }
            var command = Console.ReadLine();
            if (command == "even")
            {
                result.RemoveAll(x => !isEven(x));
            }
            else
            {
                result.RemoveAll(x => isEven(x));
            }

            Console.WriteLine(string.Join(' ', result));


        }
    }
}
