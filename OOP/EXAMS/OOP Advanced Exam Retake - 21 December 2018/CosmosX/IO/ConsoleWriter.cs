﻿using System;
using System.IO;
using CosmosX.IO.Contracts;

namespace CosmosX.IO
{
    public class ConsoleWriter : IWriter
    {
        //public void WriteLine(string output)
        //{
        //    Console.WriteLine(output);

        //}

        public void WriteLine(string output)
        {
            File.AppendAllText("../../../OutPut.txt", output+Environment.NewLine);
        }
    }
}