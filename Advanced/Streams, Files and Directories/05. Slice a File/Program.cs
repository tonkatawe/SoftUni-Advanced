using System;
using System.IO;

namespace _05._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new FileStream("sliceMe.txt", FileMode.OpenOrCreate);
            var parts = 4;
            var lenght = reader.Length / parts;
            byte[] buffer = new byte[lenght];
            for (int i = 0; i < parts; i++)
            {
                var bytesRead = reader.Read(buffer, 0, buffer.Length);
                var currentPartStream = new FileStream($"Text-{i + 1}.txt", FileMode.OpenOrCreate);
                currentPartStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
