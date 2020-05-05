using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _04._The_Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = ParseArrayFromConsole();
            var knives = new Stack<int>(n);
            var m = ParseArrayFromConsole();
            var forks = new Queue<int>(m);
            var result = new List<int>();
            while (forks.Any() && knives.Any())
            {
                if (knives.Peek() > forks.Peek())
                {
                    result.Add(knives.Pop()+forks.Dequeue());
                }
                else if (knives.Peek() < forks.Peek())
                {
                    knives.Pop();
                }
                else if (knives.Peek() == forks.Peek())
                {
                    forks.Dequeue();
                    knives.Push(knives.Pop() + 1);
                }
            }

            Console.WriteLine($"The biggest set is: {result.Max()}");
            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] ParseArrayFromConsole()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
