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
                var male = males.Peek();
                var female = females.Peek();
                //make check for special case
                if (male > 0 && female > 0)
                {
                    if (male % 25 == 0)
                    {
                        if (males.Count > 1)
                        {
                            males.Pop();
                            males.Pop();
                        }
                        else
                        {
                            males.Pop();
                        }
                        continue;

                    }
                    if (female % 25 == 0)
                    {
                        if (females.Count > 1)
                        {
                            females.Dequeue();
                            females.Dequeue();
                        }
                        else
                        {
                            females.Dequeue();
                        }
                        continue;
                    }
                   

                }
                //make zero and below check
                if (male <= 0 || female <= 0)
                {
                    if (male <= 0)
                    {
                        males.Pop();
                    }
                    if (female <= 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }


                //make matches check
                if (male == female)
                {
                    males.Pop();
                    females.Dequeue();
                    matches++;
                }
                else
                {
                    females.Dequeue();
                    male -= 2;
                    males.Pop();
                    males.Push(male);
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
