using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceOfBullets = int.Parse(Console.ReadLine());
            var sizeOfGunBarrel = int.Parse(Console.ReadLine());

            var inputBullet = ReadArrayFromConsole();
            var inputLocks = ReadArrayFromConsole();

            var intelligence = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(inputBullet);
            var locks = new Queue<int>(inputLocks);
            var firstBulletSize = bullets.Count;

            var count = 0;
            while (bullets.Any() && locks.Any())
            {
                var currentBullet = bullets.Peek();
                var currentLock = locks.Peek();
                count++;
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    bullets.Pop();
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                }
                if (count == sizeOfGunBarrel && bullets.Any())
                {
                    count = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                var remainBullets = firstBulletSize - bullets.Count;
                var wasteSum = priceOfBullets * remainBullets;
                var earns = intelligence - wasteSum;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earns}");
            }
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
