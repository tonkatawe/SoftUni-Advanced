using System;
using System.IO;
namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("Input.txt");
            using var writer = new StreamWriter("Output.txt");
            var count = 1;
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                writer.WriteLine($"{count}. {line}");
                count++;
            }
        }
    }
}
