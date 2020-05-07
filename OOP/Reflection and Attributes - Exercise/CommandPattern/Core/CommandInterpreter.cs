using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostfix = "Command";

        public string Read(string args)
        {
            string[] commandParts = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandParts[0] + CommandPostfix;

            string[] commandArgs = commandParts.Skip(1).ToArray();

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            Object instance = Activator.CreateInstance(type);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
