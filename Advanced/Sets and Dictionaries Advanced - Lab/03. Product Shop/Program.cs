using System;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopsProductPrice = new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Revision")
                {
                    break;
                }

                var tokens = command.Split(',', ' ', StringSplitOptions.RemoveEmptyEntries);
                var shop = tokens[0];
                var product = tokens[1];
                var price = double.Parse(tokens[2]);
                if (!shopsProductPrice.ContainsKey(shop))
                {
                    shopsProductPrice.Add(shop, new Dictionary<string, double>());
                }

                if (!shopsProductPrice[shop].ContainsKey(product))
                {
                    shopsProductPrice[shop].Add(product, price);
                }

            }

            foreach (var shop in shopsProductPrice)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var products in shop.Value)
                {
                    Console.WriteLine($"Product:{products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}
