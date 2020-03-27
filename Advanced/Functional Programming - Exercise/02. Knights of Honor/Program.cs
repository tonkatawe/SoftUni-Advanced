using System;
using System.Linq;
using System.Threading.Channels;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Action<string> specialPrint = x => Console.WriteLine($"Sir {x}");
            input.ToList().ForEach(x => specialPrint(x));
        }
    }
}
