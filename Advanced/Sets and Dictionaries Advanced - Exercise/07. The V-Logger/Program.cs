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
            var followers = new Dictionary<string, SortedSet<string>>();//use it for followers
            var folloing = new Dictionary<string, HashSet<string>>();//use it for folloing
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
                    if (!followers.ContainsKey(vloggerName))
                    {

                        followers[vloggerName] = new SortedSet<string>();
                        folloing[vloggerName] = new HashSet<string>();
                    }
                }
                else if (command == "followed")
                {
                    var otherName = tokens[2];
                    if (followers.ContainsKey(otherName) && folloing.ContainsKey(vloggerName) && vloggerName != otherName)
                    {
                        followers[otherName].Add(vloggerName);
                        if (!folloing.ContainsKey(vloggerName) && folloing.ContainsKey(otherName))
                        {
                            folloing[vloggerName] = new HashSet<string>();
                        }
                        folloing[vloggerName].Add(otherName);
                    }

                }
            }

            Console.WriteLine($"The V-Logger has a total of {followers.Count} vloggers in its logs.");
            var count = 1;

            var mostFamouse = string.Empty;
            var min = 0;
            foreach (var kvp in followers)
            {
                if (kvp.Value.Count > min)
                {
                    min = kvp.Value.Count;
                    mostFamouse = kvp.Key;
                }
            }

            Console.WriteLine($"{count}. {mostFamouse} : {followers[mostFamouse].Count} followers, {folloing[mostFamouse].Count} following");
            foreach (var kvp in followers[mostFamouse])
            {
                Console.WriteLine($"*  {kvp}");
            }

            followers.Remove(mostFamouse);

            foreach (var vlogger in followers.OrderByDescending( x => x.Value.Count).ThenByDescending( x=> x.Key))
            {
                count++;
                var name = vlogger.Key;
                Console.WriteLine($"{count}. {name} : {vlogger.Value.Count} followers, {folloing[name].Count} following");
            }
        }
    }
}
