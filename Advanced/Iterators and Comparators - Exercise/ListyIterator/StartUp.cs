using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = input
                .Split()
                .Skip(1)
                .ToList();

            ListyIterator<string> list = new ListyIterator<string>(tokens);
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                else if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                    
                }
                else if (command == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                  
                    }
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                   
                }
            }

        }
    }
}
