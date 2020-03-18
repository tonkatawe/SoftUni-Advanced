using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = ParseArrFromConsole();
            var rows = size[0];
            var cols = size[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = ParseArrFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }


            var maxSum = int.MinValue;
            var r = 0; //startIndex row of matrix
            var c = 0; //startIndex col of matrix
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                                     matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                                     matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        r = row;
                        c = col;
                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[r, c]} {matrix[r, c + 1]} {matrix[r, c + 2]}");
            Console.WriteLine($"{matrix[r + 1, c]} {matrix[r + 1, c + 1]} {matrix[r + 1, c + 2]}");
            Console.WriteLine($"{matrix[r + 2, c]} {matrix[r + 2, c + 1]} {matrix[r + 2, c + 2]}");



        }

        static int[] ParseArrFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }

}
