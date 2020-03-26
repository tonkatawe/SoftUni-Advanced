using System;
using System.IO;
namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
           var files = Directory.GetFiles(@"..\..\..\TestFolder");
           double sum = 0;
           foreach (var file in files)
           {
               FileInfo fileInfo = new FileInfo(file);
               sum += fileInfo.Length;
           }

           sum = sum / 1024 / 1024;
           var text = $"{sum:f4}  MB";
           File.WriteAllText("output.txt", text);
        }
    }
}
