using System;
using System.Linq;

namespace _1._Diagonal_Difference
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
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var firstSum = 0; //save sum of first diagonal
            var secondSum = 0;//save sum of second diagonal
            var counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                }
                firstSum += matrix[row, counter];
                secondSum += matrix[row, matrix.GetLength(1) - 1 - counter];
                counter++;
            }

            var difference = Math.Abs(firstSum - secondSum);
            Console.WriteLine(difference);
         
        }
    }
}
