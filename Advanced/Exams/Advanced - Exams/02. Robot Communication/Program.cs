using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Robot_Communication
{
    class Program
    {
        //Here is 60/100 Judge might be want to solve this problem with regEx but I'm not keen on regEx, In my view it solving is better doesn't matter whether bring full points or not :) enjoy :)
        static void Main(string[] args)
        {
            var currentWord = string.Empty;
            var result = new Queue<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Report")
                {
                    break;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == ',')
                    {
                        i++;
                        while (!char.IsDigit(input[i]))
                        {
                            currentWord += input[i];
                            i++;
                        }
                        byte[] asciiBytes = Encoding.ASCII.GetBytes(currentWord);
                        var currentDigit = char.GetNumericValue(input[i]);
                        var newWord = string.Empty;
                        for (int j = 0; j < asciiBytes.Length; j++)
                        {
                            newWord += (char)(asciiBytes[j] + currentDigit);
                        }
                        result.Enqueue(newWord);
                        currentWord = string.Empty;
                        newWord = string.Empty;
                    }
                    if (input[i] == '_')
                    {
                        i++;
                        while (!char.IsDigit(input[i]))
                        {
                            currentWord += input[i];
                            i++;
                        }
                        byte[] asciiBytes = Encoding.ASCII.GetBytes(currentWord);

                        var currentDigit = char.GetNumericValue(input[i]);
                        var newWord = string.Empty;
                        for (int j = 0; j < asciiBytes.Length; j++)
                        {
                            newWord += (char)(asciiBytes[j] - currentDigit);
                        }
                        result.Enqueue(newWord);
                        currentWord = string.Empty;
                        newWord = string.Empty;
                    }
                }

                Console.WriteLine(string.Join(" ", result));
                result.Clear();
            }
        }
    }
}
