using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var numbers = new Stack<int>();
            foreach (var number in input)
            {
                numbers.Push(number);
            }

            while (true)
            {
                var command = Console.ReadLine().ToLower().Split();
                if (command[0] == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }

                else if (command[0] == "remove" && int.Parse(command[1]) < numbers.Count)
                {
                    for (int i = 0; i < int.Parse(command[1]); i++)
                    {
                        numbers.Pop();
                    }
                }
                else if (command[0] == "end")
                {
                    break;
                }
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
