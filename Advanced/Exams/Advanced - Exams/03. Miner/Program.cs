using System;
using System.Linq;

namespace _03._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new string[size, size];
            var commands = ReadArrayFromConsole();
            var coalCount = 0;
            var rowStart = 0;
            var colStart = 0;
            var minerCoal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = ReadArrayFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == "s")
                    {
                        rowStart = row;
                        colStart = col;
                    }

                    if (currentRow[col] == "c")
                    {
                        coalCount++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up")
                {
                    if (rowStart - 1 >= 0)
                    {
                        rowStart--;
                        if (matrix[rowStart, colStart] == "e")
                        {
                            Console.WriteLine($"Game over! ({rowStart}, {colStart})");
                            return;
                        }
                        else if (matrix[rowStart, colStart] == "c")
                        {
                            minerCoal++;
                            coalCount--;
                            matrix[rowStart, colStart] = "*";
                        }
                    }
                }
                else if (commands[i] == "down")
                {
                    if (rowStart + 1 < size)
                    {
                        rowStart++;
                        if (matrix[rowStart, colStart] == "e")
                        {
                            Console.WriteLine($"Game over! ({rowStart}, {colStart})");
                            return;
                        }
                        else if (matrix[rowStart, colStart] == "c")
                        {
                            minerCoal++;
                            coalCount--;
                            matrix[rowStart, colStart] = "*";
                        }
                    }
                }
                else if (commands[i] == "left")
                {
                    if (colStart - 1 >= 0)
                    {
                        colStart--;
                        if (matrix[rowStart, colStart] == "e")
                        {
                            Console.WriteLine($"Game over! ({rowStart}, {colStart})");
                            return;
                        }
                        else if (matrix[rowStart, colStart] == "c")
                        {
                            minerCoal++;
                            coalCount--;
                            matrix[rowStart, colStart] = "*";
                        }
                    }
                }
                else if (commands[i] == "right")
                {
                    if (colStart + 1 < size)
                    {
                        colStart++;
                        if (matrix[rowStart, colStart] == "e")
                        {
                            Console.WriteLine($"Game over! ({rowStart}, {colStart})");
                            return;
                        }
                        else if (matrix[rowStart, colStart] == "c")
                        {
                            minerCoal++;
                            coalCount--;
                            matrix[rowStart, colStart] = "*";
                        }
                    }
                }

                if (coalCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({rowStart}, {colStart})");
                    return;
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({rowStart}, {colStart})");
        }

        private static string[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
