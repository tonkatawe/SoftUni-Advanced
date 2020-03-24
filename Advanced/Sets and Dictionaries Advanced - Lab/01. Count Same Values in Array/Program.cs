using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            var dict = new Dictionary<double, int>();
            foreach (var digit in input)
            {
                if (!dict.ContainsKey(digit))
                {
                    dict[digit] = 1;
                }
                else
                {
                    dict[digit]++;
                }
            }

            foreach (var digit in dict)
            {
                Console.WriteLine($"{digit.Key} - {digit.Value} times");
            }
        }
    }
}
