using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        //80/100 might be need to make 2 lists for guests :)
        static void Main(string[] args)
        {
            var guests = new HashSet<string>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                if (command == "PARTY")
                {
                    var test = string.Empty;
                    while (test != "END")
                    {
                        test = Console.ReadLine();
                        if (guests.Contains(test))
                        {
                            guests.Remove(test);

                        }
                    }

                    break;
                }

                if (command.Length == 8)
                {
                    guests.Add(command);
                }
            }

            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
