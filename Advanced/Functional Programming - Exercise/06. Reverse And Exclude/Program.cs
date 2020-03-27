using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> reverse = x => x.Reverse();


            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            reverse(numbers);
            var divider = int.Parse(Console.ReadLine());
            Func<int, bool> divide = x => x % divider != 0;
            var result = numbers.Where(divide);
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
