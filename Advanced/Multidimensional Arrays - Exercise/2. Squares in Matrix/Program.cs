using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var rows = size[0];
            var cols = size[1];
            var matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col].ToString();
                }
            }

            var counter = 0; //counter for equal matrix
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row+1, col+1] && matrix[row, col] == matrix[row+1, col])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }


    }
}
