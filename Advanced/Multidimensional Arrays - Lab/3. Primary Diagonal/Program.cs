using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfMatrixSquer = int.Parse(Console.ReadLine());

            var matrix = new int[sizeOfMatrixSquer, sizeOfMatrixSquer];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var curr = 0;
            var sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                }
                sum += matrix[curr, curr];
                curr++;
            }

            Console.WriteLine(sum);
        }
    }
}
