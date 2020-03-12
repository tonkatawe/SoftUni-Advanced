using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        //best solution ever is below such a comment :)
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //while (input.Contains("{}") || input.Contains("[]") || input.Contains("()"))
            //{
            //    input = input.Replace("{}", "");
            //    input = input.Replace("[]", "");
            //    input = input.Replace("()", "");
            //}
            //if (input.Length == 0)
            //{
            //    Console.WriteLine("YES");
            //}
            //else
            //{
            //    Console.WriteLine("NO");
            //}
            var parenthesis = Console.ReadLine().ToCharArray();
            var stack = new Stack<char>();
            for (int i = 0; i < parenthesis.Length; i++)
            {
                var curr = parenthesis[i];
                if (curr == '{' || curr == '(' || curr == '[' || !stack.Any())
                {
                    stack.Push(curr);
                }
                else if (stack.Peek() == '{' && curr == '}' && stack.Any())
                {
                    stack.Pop();


                }
                else if (stack.Peek() == '(' && curr == ')' && stack.Any())
                {
                    stack.Pop();


                }
                else if (stack.Peek() == '[' && stack.Any() && curr == ']')
                {
                    stack.Pop();

                }


            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
