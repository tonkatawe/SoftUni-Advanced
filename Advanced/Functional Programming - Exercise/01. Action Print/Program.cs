using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split();
            Action<string> printString = p => Console.WriteLine(p);
            input.ToList().ForEach(x => printString(x));
        }
    }
}
