using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _07._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("text.txt");
            using var writer = new StreamWriter("output.txt");
            var count = 0;
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (count % 2 == 0)
                {
                    for (int i = 0; i < line.Length; i++)
                    {

                        var currentChar = line[i];
                        if (currentChar == ',' || currentChar == '-' || currentChar == '.' ||
                            currentChar == '?' || currentChar == '!')
                        {
                            line = line.Replace(currentChar, '@');
                        }

                    }
                    var currentArr = line.Split();
                    Array.Reverse(currentArr);
                    writer.WriteLine($"{string.Join(" ", currentArr)}");
                }

                count++;
            }
        }
    }
}
