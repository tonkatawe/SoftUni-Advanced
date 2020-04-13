using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var stack = new MyStack<int>();
            
            while (true)
            {
                var inpuut = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var command = inpuut[0];

                if (command == "END")
                {
                    break;
                }

                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                     
                    }
                }

                
                if (command == "Push")
                {
                    var items = inpuut.Skip(1)
                        .Select(i => i.Split(',').First())
                        .Select(int.Parse)
                        .ToArray();
                    stack.Push(items);
                }

            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            /*
              01. ListyIterator
              02. Collection

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
                else if (command == "PrintAll")
                {
                    list.PrintAll();
                }
            }
            */

        }
    }
}
