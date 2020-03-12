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
            var petrol = new Queue<int>();
            var distance = new Queue<int>();

            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                var pairAmountPetrolAndDistance = Console.ReadLine().Split().Select(int.Parse).ToArray();
                petrol.Enqueue(pairAmountPetrolAndDistance[0]);
                distance.Enqueue(pairAmountPetrolAndDistance[1]);

            }
            var currentFuel = 0;
            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                currentFuel = petrol.Peek();
                for (int j = 0; j < numberOfPetrolPumps; j++)
                {
                    if (distance.Peek() <= currentFuel)
                    {
                        currentFuel -= distance.Peek();
                        if (j == numberOfPetrolPumps - 1)
                        {
                            Console.WriteLine(i);
                            return;
                        }
                    }
                    else
                    {
                        for (int k = j; k < numberOfPetrolPumps; k++)
                        {
                            petrol.Enqueue((petrol.Dequeue()));
                            distance.Enqueue(distance.Dequeue());
                        }
                        break;
                    }
                    petrol.Enqueue(petrol.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                    currentFuel += petrol.Peek();
                }
                petrol.Enqueue(petrol.Dequeue());
                distance.Enqueue(distance.Dequeue());
            }
        }
    }
}
