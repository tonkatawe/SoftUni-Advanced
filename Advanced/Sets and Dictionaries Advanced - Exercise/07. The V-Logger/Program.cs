using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, HashSet<string>>>();//use it for all data
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                var tokens = input.Split();
                var vloggerName = tokens[0];
                var command = tokens[1];
                if (command == "joined")
                {
                    if (!data.ContainsKey(vloggerName))
                    {
                        data.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        data[vloggerName].Add("followers", new HashSet<string>());
                        data[vloggerName].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    var member = tokens[2];
                    if (data.ContainsKey(vloggerName) && data.ContainsKey(member) && member != vloggerName)
                    {

                        data[vloggerName]["following"].Add(member);
                        data[member]["followers"].Add(vloggerName);
                    }

                }
            }

            Console.WriteLine($"The V-Logger has a total of {data.Count} vloggers in its logs.");
            var count = 1;

            foreach (var vlogger in data.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (count == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}
