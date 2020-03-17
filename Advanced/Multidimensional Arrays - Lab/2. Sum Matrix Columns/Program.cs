using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = ParseArrFromConsole(new[] { ' ', ',' });

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentElements = ParseArrFromConsole(new[] { ' ' });
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentElements[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }



        }

        static int[] ParseArrFromConsole(char[] splitSymbols)
        {
            return Console.ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
