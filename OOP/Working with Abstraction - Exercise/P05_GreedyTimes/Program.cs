using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class GreedyTimes
    {
        static void Main(string[] args)
        {
            var entire = long.Parse(Console.ReadLine());
            var depositBox = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            var gold = 0;
            var gems = 0;
            var money = 0;

            for (int i = 0; i < depositBox.Length; i += 2)
            {
                var name = depositBox[i];
                var count = int.Parse(depositBox[i + 1]);

                var item = string.Empty;

                if (name.Length == 3)
                {
                    item = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    item = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    item = "Gold";
                }

                if (item == "")
                {
                    continue;
                }
                else if (entire < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (item)
                {
                    case "Gem":
                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(item))
                {
                    bag[item] = new Dictionary<string, long>();
                }

                if (!bag[item].ContainsKey(name))
                {
                    bag[item][name] = 0;
                }

                bag[item][name] += count;
                if (item == "Gold")
                {
                    gold += count;
                }
                else if (item == "Gem")
                {
                    gems += count;
                }
                else if (item == "Cash")
                {
                    money += count;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}