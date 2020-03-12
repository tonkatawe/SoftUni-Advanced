using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); // number of operations
            var stack = new Stack<string>();
            var result = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var instruction = tokens[0];
                if (instruction == "1")
                {
                    stack.Push(result);
                    var stringToAppend = tokens[1];
                    result += stringToAppend;
                }
                else if (instruction == "2")
                {
                    stack.Push(result);
                    var index = int.Parse(tokens[1]);
                   result = result.Substring(0, result.Length - index);
                    
                }
                else if (instruction == "3")
                {
                    var index = int.Parse(tokens[1]);


                    Console.WriteLine(result[index - 1]);


                }
                else if (instruction == "4")
                {
                    if (stack.Count > 0)
                    {
                        result = stack.Pop();
                    }
                    else
                    {
                        result = string.Empty;
                    }

                }
            }
        }
    }
}