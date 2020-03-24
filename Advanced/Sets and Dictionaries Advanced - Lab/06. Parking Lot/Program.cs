using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            var carNumbers = new HashSet<string>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command== "END")
                {
                    break;  
                }

                var tokens = command.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "IN")
                {
                    carNumbers.Add(tokens[1]);
                }
                else if (tokens[0] == "OUT" && carNumbers.Contains(tokens[1]))
                {
                    carNumbers.Remove(tokens[1]);
                }
            }

            if (carNumbers.Count >0)
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
