using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Catapult_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); //read number of Trojan`s rock piles
            var m = ParseArrayFromConsole();
            var walls = new Queue<int>(m);
            var rocks = new Stack<int>();
            //now read piles with rocks
            for (int i = 1; i <= n; i++)
            {

                if (!walls.Any())
                {
                    break;
                }
                var curPile = ParseArrayFromConsole();

                rocks = new Stack<int>(curPile);
                if (i % 3 == 0)
                {
                    var newWall = int.Parse(Console.ReadLine());
                    walls.Enqueue(newWall);
                }


                while (rocks.Any() && walls.Any())
                {
                    var currentWall = walls.Peek();
                    var currentRock = rocks.Peek();
                    if (currentWall == currentRock)
                    {
                        walls.Dequeue();
                        rocks.Pop();
                    }
                    else if (currentRock > currentWall)
                    {
                        rocks.Pop();
                        walls.Dequeue();
                        rocks.Push(currentRock - currentWall);

                    }
                    else if (currentRock < currentWall)
                    {
                        rocks.Pop();
                        walls.Enqueue(currentWall - currentRock);
                        walls.Dequeue();
                        for (int j = 0; j < walls.Count - 1; j++)
                        {
                            walls.Enqueue(walls.Dequeue());
                        }
                    }

                }
            }

            if (!rocks.Any())
            {

                Console.WriteLine($"Walls left: {string.Join(", ", walls)}");
            }
            else
            {
                Console.WriteLine($"Rocks left: {string.Join(", ", rocks)}");

            }
        }
        private static int[] ParseArrayFromConsole()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

    }
}
