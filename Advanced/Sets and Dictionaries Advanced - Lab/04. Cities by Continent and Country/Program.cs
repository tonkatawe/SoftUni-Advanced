using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var contsData = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var continent = input[0];
                var country = input[1];
                var city = input[2];
                if (!contsData.ContainsKey(continent))
                {
                    contsData.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!contsData[continent].ContainsKey(country))
                {
                    contsData[continent].Add(country, new List<string>());
                }
                contsData[continent][country].Add(city);
            }

            foreach (var continent in contsData)
            {
                var continentName = continent.Key;
                Console.WriteLine($"{continentName}:");
               
                foreach (var country in continent.Value)
                {
                    var countryName = country.Key;
                    var cities = country.Value;
                    Console.WriteLine($"  {countryName} -> {string.Join(", ", cities)}");
                }

            }
        }
    }
}
