using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPetrolPumps = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var distancePerLiter = 1;
            var smallestIndex = int.MinValue;

            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                var pairAmountPetrolAndDistance = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var AmountOfPetrol = pairAmountPetrolAndDistance[0];
                var distanceFromPumpToPump = pairAmountPetrolAndDistance[1];

            }

            Console.WriteLine(stack.Min());
        }
    }
}
