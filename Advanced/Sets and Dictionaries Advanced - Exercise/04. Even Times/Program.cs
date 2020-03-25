using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var count = 0;
            var result = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                if (!result.ContainsKey(input))
                {
                    result[input] = 0;
                }
                result[input]++;
            }

            foreach (var digit in result)
            {
                if (digit.Value % 2==0)
                {
                    Console.WriteLine(digit.Key);
                }
            }
        }
    }
}
