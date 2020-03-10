using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfpassedCars = int.Parse(Console.ReadLine());
            var carsQueue = new Queue<string>();
            var passedCar = 0;
            while (true)
            {
                var car = Console.ReadLine();
                if (car == "green")
                {
                    for (int i = 0; i < numberOfpassedCars; i++)
                    {
                        if (carsQueue.Count < 1)
                        {
                            break;
                        }

                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                        passedCar++;
                    }
                }
                else if (car == "end")
                {
                    break;
                }
                else
                {
                    carsQueue.Enqueue(car);
                }

            }
            Console.WriteLine($"{passedCar} cars passed the crossroads.");

        }
    }
}


