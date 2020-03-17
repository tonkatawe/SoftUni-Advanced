using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCows = ParsedArrFromConsole();
            var matrix = new int[rowsAndCows[0], rowsAndCows[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = ParsedArrFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            var maxSum = int.MinValue;
            var r = 0; //startIndex of matrix row
            var c = 0; //startIndex of matric col
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var sum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        r = row;
                        c = col;

                    }
                }
            }

            Console.WriteLine($"{matrix[r, c]} {matrix[r, c + 1]}");
            Console.WriteLine($"{matrix[r + 1, c]} {matrix[r + 1, c + 1]}");
            Console.WriteLine(maxSum);
        }
        static int[] ParsedArrFromConsole()
        {
            return Console.ReadLine()
                .Split(',', ' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
