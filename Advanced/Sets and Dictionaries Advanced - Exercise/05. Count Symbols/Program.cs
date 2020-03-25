using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToCharArray();
            var result = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];
                if (!result.ContainsKey(symbol))
                {
                    result[symbol] = 0;
                }

                result[symbol]++;
            }

            foreach (var symbol in result)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
