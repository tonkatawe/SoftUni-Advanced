using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("Input.txt");
            using var writer = new StreamWriter("Ouput.txt");
            var counter = 0;
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (counter % 2 == 1)
                {
                    writer.WriteLine(line);
                }

                counter++;
            }
        }
    }
}
