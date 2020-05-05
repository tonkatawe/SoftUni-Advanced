using System;
using System.Linq;

namespace _03._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            //read all bomb fields as array split by whitespace 
            var bombFields = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombFields.Length; i++)
            {
                var currentBombCordinates = bombFields[i]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                var bombRow = currentBombCordinates[0];
                var bombCol = currentBombCordinates[1];
                var bombSize = matrix[bombRow, bombCol];
                if (bombSize <= 0)
                {
                    continue;

                }
                matrix[bombRow, bombCol] = 0;
                if (bombRow + 1 < size)
                {
                    if (matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= bombSize;
                    }
                }
                if (bombRow - 1 >= 0)
                {
                    if (matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= bombSize;
                    }

                }
                if (bombCol - 1 >= 0)
                {
                    if (matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bombSize;
                    }
                }
                if (bombCol + 1 < size)
                {
                    if (matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= bombSize;
                    }
                }

                if (bombCol + 1 < size && bombRow + 1 < size)
                {
                    if (matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombSize;

                    }
                }
                if (bombCol - 1 >= 0 && bombRow - 1 >= 0)
                {
                    if (matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombSize;
                    }
                }
                if (bombCol + 1 < size && bombRow - 1 >= 0)
                {
                    if (matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombSize;
                    }
                }
                if (bombCol - 1 >= 0 && bombRow + 1 < size)
                {
                    if (matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombSize;
                    }
                }
            }
            var sumOfCells = 0;
            var alaiveCells = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        alaiveCells++;
                        sumOfCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {alaiveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
