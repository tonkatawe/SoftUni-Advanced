using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _01._Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = ParseArrayFromConsole();
            var m = ParseArrayFromConsole();
            var boxesWithMatirial = new Stack<int>(n);
            var magicValues = new Queue<int>(m);

            while (boxesWithMatirial.Count !=0 && magicValues.Count !=0)
            {
                var currentMagic = boxesWithMatirial.Peek() * magicValues.Peek();
                if (currentMagic == 150 || currentMagic == 250 || currentMagic == 300 || currentMagic ==400)
                {
                    boxesWithMatirial.Pop();
                    magicValues.Dequeue();
                }
                else if (currentMagic <0)
                {
                    var sum = boxesWithMatirial.Pop() + magicValues.Dequeue();
                    boxesWithMatirial.Push(sum);
                }
                else if (currentMagic >0)
                {
                    magicValues.Dequeue();
                    var current = boxesWithMatirial.Pop() + 15;
                    boxesWithMatirial.Push(current);
                }

                if (boxesWithMatirial.Peek() == 0)
                {
                    boxesWithMatirial.Pop();
                }

                if (magicValues.Peek() == 0)
                {
                    magicValues.Dequeue();
                }

            }

        }
        public static int[] ParseArrayFromConsole()
        {
            return Console.ReadLine()
              .Split(' ', StringSplitOptions.None)
              .Select(int.Parse)
              .ToArray();
        }
    }
}
