using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            using var wordReader = new StreamReader("words.txt");
            var words = wordReader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries); //here save all words in array
            using var textReader = new StreamReader("text.txt");
            var appearedWords = new Dictionary<string, int>();
            using var writer = new StreamWriter("Output.txt");
            while (true)
            {
                var line = textReader.ReadLine();
                if (line == null)
                {
                    break;
                }
                var currentLine = line.ToLower().Split(' ',',','.','!','?','-').ToArray(); //read all lines
                for (int word = 0; word < words.Length; word++)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        if (words[word] == currentLine[i])
                        {
                            if (!appearedWords.ContainsKey(words[word]))
                            {
                                appearedWords[words[word]] = 0;
                            }

                            appearedWords[words[word]]++;
                        }
                    }
                }
            }

            foreach (var word in appearedWords.OrderByDescending(x => x.Value))
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
