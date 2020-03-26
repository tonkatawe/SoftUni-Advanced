using System;
using System.IO;

namespace _04._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using var firstFile = new StreamReader("FileOne.txt");
            using var secondFile = new StreamReader("FileTwo.txt");
            using var writer = new StreamWriter("Output.txt");
            var lineOne = firstFile.ReadLine();
            var lineTwo = secondFile.ReadLine();
            while (lineTwo != null || lineOne != null)
            {
                writer.WriteLine(lineOne);
                writer.WriteLine(lineTwo);
                lineOne = firstFile.ReadLine();
                lineTwo = secondFile.ReadLine();
            }
        }
    }
}
