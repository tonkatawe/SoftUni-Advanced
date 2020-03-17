using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = ParseArrFromConsole();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var colElements = ParseArrFromConsole();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            var sum = 0;
            foreach (var elements in matrix)
            {
                sum += elements;
            }

            Console.WriteLine(sum);
        }
        static int[] ParseArrFromConsole()
        {
            return Console.ReadLine()
                .Split(',', ' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}
