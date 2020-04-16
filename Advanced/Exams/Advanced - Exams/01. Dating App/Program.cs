using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _01._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();//read males
            var f = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();//read females
            var males = new Stack<int>(m);
            var females = new Queue<int>(f);
            var matches = 0;

            while (males.Count != 0 && females.Count != 0)
            {
                if (males.Any())
                {
                    if (males.Peek() <= 0)
                    {
                        males.Pop();
                        continue;

                    }
                }
                if (females.Any())
                {
                    if (females.Peek() <= 0)
                    {
                        females.Dequeue();
                        continue;

                    }
                }

                if (males.Count >= 2)
                {
                    if (males.Peek() % 25 == 0)
                    {
                        males.Pop();
                        males.Pop();
                    }

                    if (males.Count == 0)
                    {
                        break;
                    }
                }

                if (females.Count >= 2)
                {
                    if (females.Peek() % 25 == 0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }

                    if (females.Count == 0)
                    {
                        break;
                    }
                }

                if (males.Peek() == females.Peek())
                {
                    males.Pop();
                    females.Dequeue();
                    matches++;
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }
                
            }

            Console.WriteLine($"Matches: {matches}");
            if (males.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }

            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine($"Females left: none");
            }
        }
    }
}
