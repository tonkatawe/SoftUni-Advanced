using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var queque = new Queue<int>();
            foreach (var que in input)
            {
                if (que % 2 == 0)
                {
                    queque.Enqueue(que);
                }
            }

            Console.WriteLine(string.Join(", ", queque));
        }
    }
}
