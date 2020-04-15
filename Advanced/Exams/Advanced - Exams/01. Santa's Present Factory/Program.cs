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
            var data = new SortedDictionary<string, int>();
            data["Doll"] = 0;
            data["Wooden train"] = 0;
            data["Teddy bear"] = 0;
            data["Bicycle"] = 0;
            while (boxesWithMatirial.Count != 0 && magicValues.Count != 0)
            {
                var currentMagic = boxesWithMatirial.Peek() * magicValues.Peek();
                if (currentMagic == 150 || currentMagic == 250 || currentMagic == 300 || currentMagic == 400)
                {
                    boxesWithMatirial.Pop();
                    magicValues.Dequeue();
                    switch (currentMagic)
                    {
                        case 150:
                            data["Doll"]++;
                            break;
                        case 250:
                            data["Wooden train"]++;
                            break;
                        case 300:
                            data["Teddy bear"]++;
                            break;
                        case 400:
                            data["Bicycle"]++;
                            break;
                        default:
                            break;
                    }

                }
                else if (currentMagic < 0)
                {
                    var sum = boxesWithMatirial.Pop() + magicValues.Dequeue();
                    boxesWithMatirial.Push(sum);
                }
                else if (currentMagic > 0)
                {
                    magicValues.Dequeue();
                    var current = boxesWithMatirial.Pop() + 15;
                    boxesWithMatirial.Push(current);
                }

                else if (boxesWithMatirial.Peek() == 0 || magicValues.Peek() == 0)
                {
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

            if ((data["Doll"] > 0 && data["Wooden train"] > 0) || (data["Teddy bear"] > 0 && data["Bicycle"] > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (boxesWithMatirial.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", boxesWithMatirial)}");
            }

            if (magicValues.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicValues)}");
            }

            foreach (var toy in data.Where(x => x.Value > 0))
            {
                Console.WriteLine($"{toy.Key}: {toy.Value}");
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
