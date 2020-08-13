using System.IO;

namespace TheTankGame.IO
{
    using System;
    using System.Text;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
        //public void WriteLine(string output)
        //{
        //    File.AppendAllText("../../../OutPut.txt", output +Environment.NewLine);
        //}
    }
}