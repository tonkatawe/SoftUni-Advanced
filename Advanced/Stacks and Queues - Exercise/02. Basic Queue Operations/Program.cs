using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace _02._Basic_Queue_Operations
{
    class Program
    {   //75/100 have to check ? why
        static void Main(string[] args)
        {
            var nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();
            for (int i = 0; i < nsx[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < nsx[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(nsx[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                var minNum = int.MaxValue;
                for (int i = 0; i < queue.Count; i++)
                {
                    if (queue.Peek() < minNum)
                    {
                        minNum = queue.Dequeue();
                    }
                }

                Console.WriteLine(minNum);
            }

        }
    }
}
