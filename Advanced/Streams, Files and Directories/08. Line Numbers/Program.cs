using System;
using System.IO;

namespace _08._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("text.txt");
            using var writer = new StreamWriter("output.txt");
            var count = 1;
            while (true)
            {
                var letter = 0;
                var symbol = 0;
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                foreach (var character in line)
                {
                    if (char.IsLetterOrDigit(character))
                    {
                        letter++;
                    }
                    else if (char.IsPunctuation(character))
                    {
                        symbol++;
                    }
                }
                writer.WriteLine($"Line {count}: {line} ({letter})({symbol})");

            }
        }
    }
}
