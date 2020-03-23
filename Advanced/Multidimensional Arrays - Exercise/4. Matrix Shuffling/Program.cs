using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = ParsedArrFromConsole();
            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);
            var matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = ParsedArrFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            while (true)
            {
                var command = Console.ReadLine().ToLower();
                if (command == "end")
                {
                    break;
                }

                var tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (tokens.Length == 5)
                {
                    var instruction = tokens[0];
                    var rowOne = int.Parse(tokens[1]);
                    var colOne = int.Parse(tokens[2]);
                    var rowTwo = int.Parse(tokens[3]);
                    var colTwo = int.Parse(tokens[4]);

                    if (instruction == "swap")
                    {
                        if (rowOne >= 0 && rowOne < matrix.GetLength(0) && rowTwo >= 0 &&
                            rowTwo < matrix.GetLength(0) &&
                            colOne >= 0 && colOne < matrix.GetLength(1) && colTwo >= 0 && colTwo < matrix.GetLength(1))
                        {
                            var temp = matrix[rowTwo, colTwo];
                            matrix[rowTwo, colTwo] = matrix[rowOne, colOne];
                            matrix[rowOne, colOne] = temp;
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row, col] + " ");
                                }

                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static string[] ParsedArrFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
