using System;
using System.Threading;

namespace _04._Travel_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                var tokens = command.Split(" > ", StringSplitOptions.RemoveEmptyEntries);
                var country = tokens[0];
                var town = tokens[1];
                var cost = int.Parse(tokens[2]);
            }
        }
    }
}
