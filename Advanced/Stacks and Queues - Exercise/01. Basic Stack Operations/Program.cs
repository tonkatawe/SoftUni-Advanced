using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var nsx = Console.ReadLine().Split().Select(int.Parse).ToArray(); //read three numbers N, S and X
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray(); // read second line

            var numberOfElements = nsx[0]; //N
            var popElements = nsx[1]; //S
            var equalNumber = nsx[2]; //X
            var stack = new Stack<int>();
            for (int i = 0; i < nsx[0]; i++) //implementation for N
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < nsx[1]; i++) //thenBy S
            {
                stack.Pop();
            }
            if (stack.Contains(equalNumber)) // check for cases :)
            {
                Console.WriteLine("true");
            }
            else if (!stack.Any())
            {
                Console.WriteLine("0");
            }
            else
            {
                var minInt = int.MaxValue;
                for (int i = 0; i < stack.Count; i++)
                {
                    if (stack.Peek() < minInt)
                    {
                        minInt = stack.Pop();
                    }
                }

                Console.WriteLine(minInt);
            }
        }
    }
}
