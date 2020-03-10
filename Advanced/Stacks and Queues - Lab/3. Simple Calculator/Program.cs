using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var stack = new Stack<string>(numbers.Reverse());
            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string operators = stack.Pop();
                int second = int.Parse(stack.Pop());
                switch (operators)
                {
                    case "+":
                        stack.Push((first + second).ToString());
                        break;
                    case "-":
                        stack.Push((first - second).ToString());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stack.Pop());

        }
    }
}
