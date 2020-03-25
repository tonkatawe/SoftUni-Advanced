using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestAndPaswd = new Dictionary<string, string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }

                var tokens = input.Split(':');
                var contest = tokens[0];
                var passwd = tokens[1];
                if (!contestAndPaswd.ContainsKey(contest))
                {
                    contestAndPaswd[contest] = string.Empty;
                }

                contestAndPaswd[contest] = passwd;
            }
            var userContentsPoints = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }

                var tokens = input.Split("=>");
                var contest = tokens[0];
                var passwd = tokens[1];
                var user = tokens[2];
                var points = int.Parse(tokens[3]);
                if (contestAndPaswd.ContainsKey(contest) && contestAndPaswd[contest] == passwd)
                {
                    if (!userContentsPoints.ContainsKey(user))
                    {
                        userContentsPoints[user] = new Dictionary<string, int>();
                        userContentsPoints[user][contest] = points;
                    }
                    else
                    {

                        if (userContentsPoints[user].ContainsKey(contest) && userContentsPoints[user][contest] > points)
                        {
                           continue;
                        }
                        else
                        {
                            userContentsPoints[user][contest] = points;
                        }
                    }
                

                }
            }

            var bestCandidate = string.Empty;
            var bestScore = int.MinValue;
            var sum = 0;
            foreach (var candidate in userContentsPoints)
            {
                var name = candidate.Key;
                foreach (var kvp in candidate.Value)
                {
                    sum += kvp.Value;
                }

                if (sum > bestScore)
                {
                    bestScore = sum;
                    bestCandidate = name;
                }

                sum = 0;
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestScore} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidate in userContentsPoints.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{candidate.Key}");
                foreach (var contest in candidate.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
