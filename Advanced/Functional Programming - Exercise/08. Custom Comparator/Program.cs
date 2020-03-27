using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Func<int, int, int> comparator = (n1, n2) =>
            {
                if ((n1 % 2 == 0 && n2 % 2 != 0))
                {
                    return -1;
                }

                if ((n1 % 2 != 0 && n2 % 2 == 0))
                {
                    return 1;
                }

                return n1.CompareTo(n2);
            };

            Array.Sort<int>(numbers, new Comparison<int>(comparator));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
