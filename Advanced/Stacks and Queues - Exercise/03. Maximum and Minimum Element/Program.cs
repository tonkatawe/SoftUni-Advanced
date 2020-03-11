using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfQueries = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            if (numberOfQueries >= 1 && numberOfQueries <= 105)
            {
                for (int i = 0; i < numberOfQueries; i++)
                {
                    var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    int instruction = command[0];
                    if (instruction >= 1 && instruction <= 4)
                    {

                        if (instruction == 1)
                        {
                            if (command[1] >= 1 && command[1] <= 109)
                            {

                                stack.Push(command[1]);
                            }
                        }
                        else if (instruction == 2 && stack.Any())
                        {
                            stack.Pop();
                        }
                        else if (instruction == 3 && stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }
                        else if (instruction == 4 && stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                    }
                }

                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
