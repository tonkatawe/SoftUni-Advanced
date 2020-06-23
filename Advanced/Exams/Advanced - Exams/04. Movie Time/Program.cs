using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Movie_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            var genre = Console.ReadLine();
            var durations = Console.ReadLine();
            var data = new Dictionary<string, Dictionary<string, TimeSpan>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "POPCORN!")
                {
                    break;
                }

                var tokens = input
                    .Split('|')
                    .ToArray();
                var name = tokens[0];
                var type = tokens[1];
                var duration = tokens[2];
                TimeSpan time = DateTime.ParseExact(duration, "HH:mm:ss", CultureInfo.InvariantCulture).TimeOfDay;

                if (!data.ContainsKey(type))
                {
                    data[type] = new Dictionary<string, TimeSpan>();
                }

                data[type][name] = time;
            }

            TimeSpan sum = new TimeSpan();
            foreach (var ganre in data)
            {
                foreach (var film in ganre.Value)
                {
                    sum += film.Value;
                }
            }

            var result = new KeyValuePair<string, TimeSpan>();
                var current = data.FirstOrDefault(x => x.Key == genre);
            while (true)
            {

                if (durations == "Short")
                {
                    var movie = current.Value.OrderBy(x => x.Value).FirstOrDefault();
                    Console.WriteLine(movie.Key);
                    result = movie;
                }
                else
                {
                    var movie = current.Value.OrderByDescending(x => x.Value).FirstOrDefault();
                    Console.WriteLine(movie.Key);
                    result = movie;

                }
                var yesOrNope = Console.ReadLine();
                if (yesOrNope == "Yes")
                {
                    Console.WriteLine($"We're watching {result.Key} - {result.Value.ToString()}");
                    Console.WriteLine($"Total Playlist Duration: {sum.ToString()}");
                    break;
                }
                else
                {
                    current.Value.Remove(result.Key);
                }
            }
        }
    }
}
