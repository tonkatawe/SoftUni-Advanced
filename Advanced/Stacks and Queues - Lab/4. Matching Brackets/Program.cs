using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    //•	Scan through the expression searching for brackets => 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
    //o   If you find an opening bracket, push the index into the stack
    //o   If you find a closing bracket pop the topmost element from the stack.This is the index of the opening bracket.
    //o   Use the current and the popped index to extract the sub-expression

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                var ch = input[i];
                if (ch == '(')
                {
                    stack.Push(i);

                }
                else if (ch == ')')
                {
                    int startIndex = stack.Pop();
                    var contents = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(contents);
                }


            }
        }
    }
}
