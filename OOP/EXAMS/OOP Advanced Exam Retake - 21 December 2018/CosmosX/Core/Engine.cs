using System;
using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = true;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string line = this.reader.ReadLine();
                List<string> arguments = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                string output = this.commandParser.Parse(arguments);
                this.writer.WriteLine(output);

                this.isRunning = this.ShouldContinue(line);
            }

     
        }
        private bool ShouldContinue(string line)
        {
            return line != "Exit";
        }
    }
}