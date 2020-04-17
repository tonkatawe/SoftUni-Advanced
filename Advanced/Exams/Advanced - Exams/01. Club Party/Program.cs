using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); // read maximum hall capacity
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray(); //use for read input
            var peopleAndHalls = new Stack<string>(input);
            var halls = new Queue<char>(); //data is going to use fore store hall(data.key) and people (data.value)
            var people = new Stack<int>();
            var bigger = false; 
            while (true)
            {
                var currentHall = peopleAndHalls.Pop();
                var check = char.TryParse(currentHall, out char result);
                if (char.IsLetter(result))
                {
                    if (!halls.Contains(result))
                    {
                        halls.Enqueue(result);
                    }
                }
                else
                {
                    var cuurent = int.Parse(currentHall);
                    if (halls.Any())
                    {
                        if (people.Sum() + cuurent > n)
                        {
                            bigger = true;
                        }
                        people.Push(cuurent);

                    }
                    if (people.Sum() > n)
                    {
                        if (bigger)
                        {
                            peopleAndHalls.Push(people.Pop().ToString());
                        }
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", people.Reverse())}");
                        people.Clear();

                    }
                }

                if (peopleAndHalls.Count == 0)
                {
                    break;
                }

            }
        }
    }
}
