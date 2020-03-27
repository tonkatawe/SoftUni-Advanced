using System;
using System.Linq;
using System.Threading.Channels;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = (arr) =>
            {
                int minValue = int.MaxValue;
                foreach (var num in arr)
                {
                    if (num < minValue)
                    {
                        minValue = num;
                    }
                }

                return minValue;
            };
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(min(input));

        }


    }
}

