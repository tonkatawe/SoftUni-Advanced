using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var uniquqNames = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                uniquqNames.Add(name);
            }

            foreach (var name in uniquqNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
