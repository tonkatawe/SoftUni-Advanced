using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> add = x => x +=1;
            Func<int, int> multiply = x => x *=2;
            Func<int, int> subtract = x => x -=1;
            Action<int[]> print = x => Console.WriteLine(string.Join(' ', x));
   
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            while (true)
            {
                var instruction = Console.ReadLine();
                if (instruction == "end")
                {
                    break;
                }
                else if (instruction == "multiply")
                {
                   numbers = numbers.Select(multiply).ToArray();
                }
                else if (instruction == "add")
                {
                   numbers = numbers.Select(add).ToArray();
                }
                else if (instruction == "subtract")
                {
                  numbers=  numbers.Select(subtract).ToArray();
                }
                else if (instruction == "print")
                {
                    print(numbers);
                }
            }

           
        }
    }
}
