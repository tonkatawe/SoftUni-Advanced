using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    //70/100 but i don`t know why ? :)
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = size[0];
            var cols = size[1];
            var matrix = new char[rows, cols];
            //use two variables for player position
            var rowIndex = 0;
            var colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (currentRow[col] == 'P')
                    {
                        rowIndex = row;
                        colIndex = col;
                        matrix[row, col] = '.';
                    }
                    else
                    {
                        matrix[row, col] = currentRow[col];
                    }
                }
            }

            var commands = Console.ReadLine();
            bool dead = false;
            var currRowPosition = rowIndex;
            var currColPosition = colIndex;
            foreach (var moves in commands)
            {
                switch (moves)
                {
                    case 'U':
                        currRowPosition--;
                        break;
                    case 'D':
                        currRowPosition++;
                        break;
                    case 'L':
                        currColPosition--;
                        break;
                    case 'R':
                        currColPosition++;
                        break;
                }

                if (CheckForEscaping(currRowPosition, currColPosition, matrix))
                {
                    if (currColPosition < 0)
                    {
                        currColPosition = 0;
                    }

                    if (currColPosition == matrix.GetLength(1))
                    {
                        currColPosition--;
                    }

                    if (currRowPosition < 0)
                    {
                        currRowPosition = 0;
                    }

                    if (currRowPosition == matrix.GetLength(0))
                    {
                        currRowPosition--;
                    }
                    BunniesSpread(matrix);
                    break;
                }
                BunniesSpread(matrix);
                if (CheckForBunniesReachPlayer(currColPosition, currRowPosition, matrix))
                {
                    dead = true;
                    break;
                }

            }
            PrintMatrix(matrix);
            if (dead)
            {
                Console.WriteLine($"dead: {currRowPosition} {currColPosition}");
            }
            else
            {
                Console.WriteLine($"won: {currRowPosition} {currColPosition}");
            }
        }
        static void BunniesSpread(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (!CheckForEscaping(col - 1, row, matrix) && matrix[row, col - 1] == '.')
                        {
                            matrix[row, col - 1] = 'N';
                        }

                        if (!CheckForEscaping(col + 1, row, matrix) && matrix[row, col + 1] == '.')
                        {
                            matrix[row, col + 1] = 'N';
                        }

                        if (!CheckForEscaping(col, row + 1, matrix) && matrix[row + 1, col] == '.')
                        {
                            matrix[row + 1, col] = 'N';
                        }

                        if (!CheckForEscaping(col, row - 1, matrix) && matrix[row - 1, col] == '.')
                        {
                            matrix[row - 1, col] = 'N';
                        }
                    }
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'N')
                    {
                        matrix[row, col] = 'B';
                    }
                }
            }
        }
        static bool CheckForBunniesReachPlayer(int currColPosition, int currRowPosition, char[,] matrix)
        {
            if (matrix[currRowPosition, currColPosition] == 'B')
            {
                return true;
            }

            return false;

        }
        static bool CheckForEscaping(int currColPosition, int currRowPosition, char[,] matrix)
        {
            if (currColPosition < 0 || currColPosition >= matrix.GetLength(1) || currRowPosition < 0 ||
                currRowPosition >= matrix.GetLength(0))
            {
                return true;

            }
            return false;
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

    }
}
