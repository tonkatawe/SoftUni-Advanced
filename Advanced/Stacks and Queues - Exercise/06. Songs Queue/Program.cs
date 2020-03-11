using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ").ToArray();
            var queueSongs = new Queue<string>(songs);
            while (queueSongs.Count > 0)
            {

                var tokens = Console.ReadLine();
                //    var instruction = tokens[0];
                if (tokens.Contains("Add"))
                {
                    var song = tokens.Remove(0, 4);
                    if (!queueSongs.Contains(song))
                    {
                        queueSongs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (tokens == "Play")
                {
                    queueSongs.Dequeue();
                }
                else if (tokens == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueSongs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
