using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var n = arr[0];
            var m = arr[1];
            var setN = new HashSet<int>();
            var setM = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                setN.Add(input);
            }
            for (int i = 0; i < m; i++)
            {
                var input = int.Parse(Console.ReadLine());
                setM.Add(input);
            }


            var result = new HashSet<int>(setN);
            result.IntersectWith(setM);
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
