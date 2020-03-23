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
            var startRow = 0;
            var startCol = 0;
            var commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == "c")
                    {
                        coals++;
                    }

                    if (currentRow[col] == "s")
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            var tempRow = startRow;
            var tempCol = startCol;
            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                if (command == "up" && tempRow - 1 >= 0)
                {
                    tempRow = tempRow - 1;
                    tempCol = tempCol;
                    if (matrix[tempRow, tempCol] == "e")
                    {
                        Console.WriteLine($"Game over! ({tempRow}, {tempCol})");
                        return;
                    }
                    else if (matrix[tempRow, tempCol] == "c")
                    {
                        coals--;
                        matrix[tempRow, tempCol] = "*";
                    }
                }
                else if (command == "right" && tempCol + 1 <= size - 1)
                {
                    tempCol = tempCol + 1;
                    if (matrix[tempRow, tempCol] == "e")
                    {
                        Console.WriteLine($"Game over! ({tempRow}, {tempCol})");
                        return;
                    }
                    else if (matrix[tempRow, tempCol] == "c")
                    {
                        coals--;
                        matrix[tempRow, tempCol] = "*";
                    }

                }
                else if (command == "left" && tempCol - 1 >= 0)
                {
                    tempCol = tempCol - 1;
                    if (matrix[tempRow, tempCol] == "e")
                    {
                        Console.WriteLine($"Game over! ({tempRow}, {tempCol})");
                        return;
                    }
                    else if (matrix[tempRow, tempCol] == "c")
                    {
                        coals--;
                        matrix[tempRow, tempCol] = "*";
                    }
                }
                else if (command == "down" && tempRow + 1 <= size - 1)
                {
                    tempRow = tempRow + 1;
                    if (matrix[tempRow, tempCol] == "e")
                    {
                        Console.WriteLine($"Game over! ({tempRow}, {tempCol})");
                        return;
                    }
                    else if (matrix[tempRow, tempCol] == "c")
                    {
                        coals--;
                        matrix[tempRow, tempCol] = "*";
                    }
                }

                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({tempRow}, {tempCol})");
                    return;
                }
            }

            Console.WriteLine($"{coals} coals left. ({tempRow}, {tempCol})");


        }
    }
}
