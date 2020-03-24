using System;
using System.Linq;
using System.Net;

namespace _9._Miner
{
    class Program
    {
        /*
         100/100 but I want to alter my code!!
         */
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new string[size, size];
            var coals = 0;
            var rowIndex = 0;
            var colIndex = 0;
            var commands = ParseArrFromConsole();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = ParseArrFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == "c")
                    {
                        coals++;
                    }
                    if (currentRow[col] == "s")
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                if (command == "up" && rowIndex - 1 >= 0)
                {
                    rowIndex = rowIndex - 1;
                    colIndex = colIndex;
                    if (matrix[rowIndex, colIndex] == "e")
                    {
                        GameOver(rowIndex, colIndex);
                        return;
                    }
                    else if (matrix[rowIndex, colIndex] == "c")
                    {
                        coals--;
                        matrix[rowIndex, colIndex] = "*";
                    }
                }
                else if (command == "right" && colIndex + 1 <= size - 1)
                {
                    colIndex = colIndex + 1;
                    if (matrix[rowIndex, colIndex] == "e")
                    {
                        GameOver(rowIndex, colIndex);
                        return;
                        
                    }
                    else if (matrix[rowIndex, colIndex] == "c")
                    {
                        coals--;
                        matrix[rowIndex, colIndex] = "*";
                    }

                }
                else if (command == "left" && colIndex - 1 >= 0)
                {
                    colIndex = colIndex - 1;
                    if (matrix[rowIndex, colIndex] == "e")
                    {
                        GameOver(rowIndex, colIndex);
                        return;
                    }
                    else if (matrix[rowIndex, colIndex] == "c")
                    {
                        coals--;
                        matrix[rowIndex, colIndex] = "*";
                    }
                }
                else if (command == "down" && rowIndex + 1 <= size - 1)
                {
                    rowIndex = rowIndex + 1;
                    if (matrix[rowIndex, colIndex] == "e")
                    {
                        GameOver(rowIndex, colIndex);
                        return;
                    }
                    else if (matrix[rowIndex, colIndex] == "c")
                    {
                        coals--;
                        matrix[rowIndex, colIndex] = "*";
                    }
                }

                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                    return;
                }
            }
            Console.WriteLine($"{coals} coals left. ({rowIndex}, {colIndex})");
        }

        static void GameOver(int rowIndex, int colIndex)
        {
            Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");

        }

        static string[] ParseArrFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
