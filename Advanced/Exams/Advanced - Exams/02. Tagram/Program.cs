using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                if (command.Contains("->"))
                {
                    var tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    var username = tokens[0];
                    var tag = tokens[1];
                    var likes = int.Parse(tokens[2]);
                    if (!data.ContainsKey(username) && likes >=0)
                    {
                        data[username] = new Dictionary<string, int>();

                    }

                    if (data.ContainsKey(username) && data[username].ContainsKey(tag) && likes > 0)
                    {
                        data[username][tag] += likes;
                    }
                    else if (likes > 0)
                    {
                        data[username][tag] = likes;
                    }

                }
                else
                {
                    var userForBan = command.Split(' ').Skip(1).ToArray();
                    if (data.ContainsKey(userForBan[0]))
                    {
                        data.Remove(userForBan[0]);
                    }
                }
            }

            foreach (var user in data.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Values.Count()))
            {
                Console.WriteLine(user.Key);
                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }


}
