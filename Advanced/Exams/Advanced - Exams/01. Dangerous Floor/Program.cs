using System;
using System.Linq;

namespace _01._Dangerous_Floor
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new char[8, 8];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var currentRow = Console.ReadLine()
                    .Split(',')
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var moves = input.ToCharArray();

                var piece = moves[0];
                var startRow = (int)Char.GetNumericValue(moves[1]);
                var startCol = (int)Char.GetNumericValue(moves[2]);
                var finishRow = (int)Char.GetNumericValue(moves[4]);
                var finishCol = (int)Char.GetNumericValue(moves[5]);

                if (finishRow > matrix.GetLength(0) - 1 || finishCol > matrix.GetLength(1) - 1 || finishCol < 0 || finishRow < 0)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                if (matrix[startRow, startCol] == 'K')
                {
                    if ((startRow + 1 == finishRow || startRow - 1 == finishCol) || (startCol + 1 == finishCol || startCol - 1 == finishCol))
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'K';
                    }
                    else if ((startRow - 1 == finishRow && startCol - 1 == finishCol) || (startRow - 1 == finishRow && startCol + 1 == finishCol) || (startRow + 1 == finishRow && startCol + 1 == finishCol) || (startRow - 1 == finishRow && startCol - 1 == finishCol))
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'K';
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (matrix[startRow, startCol] == 'R')
                {
                    if (startRow == finishRow)
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'R';
                    }
                    else if (startCol == finishCol)
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'R';
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (matrix[startRow, startCol] == 'B')
                {
                    if (Math.Abs(finishCol - startCol) == Math.Abs(finishRow - startRow))
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'B';
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (matrix[startRow, startCol] == 'Q')
                {
                    if (startRow == finishRow)
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'Q';
                    }
                    else if (startCol == finishCol)
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'Q';
                    }
                    else if (Math.Abs(finishCol - startCol) == Math.Abs(finishRow - startRow))
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'Q';
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }

                }
                else if (matrix[startRow, startCol] == 'P')
                {
                    if (startRow - 1 == finishRow)
                    {
                        matrix[startRow, startCol] = 'x';
                        matrix[finishRow, finishCol] = 'P';
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                }

            }
        }
    }
}
