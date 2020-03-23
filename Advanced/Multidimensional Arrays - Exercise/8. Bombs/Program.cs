using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        //90/100 and too more code.. have to check and try to solve again
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var coordinatesArray = Console.ReadLine()
                .Split(' ')
                .ToArray();
            for (int i = 0; i < coordinatesArray.Length; i++)
            {
                var currentCoordinates = coordinatesArray[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var row = currentCoordinates[0];
                var col = currentCoordinates[1];
                var bombValue = matrix[row][col];
                if (bombValue > 0)
                {
                    matrix[row][col] = 0;
                    if (row == 0 && col == 0)
                    {
                        if (matrix[row][col + 1] > 0)
                        {
                            matrix[row][col + 1] -= bombValue;
                        }

                        if (matrix[row + 1][col] > 0)
                        {
                            matrix[row + 1][col] -= bombValue;
                        }

                        if (matrix[row + 1][col + 1] > 0)
                        {
                            matrix[row + 1][col + 1] -= bombValue;
                        }

                    }
                    else if (row == size - 1 && col == 0)
                    {
                        if (matrix[row][col + 1] > 0)
                        {

                            matrix[row][col + 1] -= bombValue;
                        }

                        if (matrix[row - 1][col] > 0)
                        {
                            matrix[row - 1][col] -= bombValue;

                        }

                        if (matrix[row - 1][col + 1] > 0)
                        {

                            matrix[row - 1][col + 1] -= bombValue;
                        }

                    }
                    else if (row == 0 && col == size - 1)
                    {
                        if (matrix[row][col - 1] > 0)
                        {
                            matrix[row][col - 1] -= bombValue;
                        }

                        if (matrix[row + 1][col] > 0)
                        {
                            matrix[row + 1][col] -= bombValue;
                        }

                        if (matrix[row + 1][col - 1] > 0)
                        {
                            matrix[row + 1][col - 1] -= bombValue;
                        }
                    }
                    else if (row == size - 1 && col == size - 1)
                    {
                        if (matrix[row][col - 1] > 0)
                        {

                            matrix[row][col - 1] -= bombValue;
                        }

                        if (matrix[row - 1][col] > 0)
                        {

                            matrix[row - 1][col] -= bombValue;
                        }

                        if (matrix[row - 1][col - 1] > 0)
                        {

                            matrix[row - 1][col - 1] -= bombValue;
                        }
                    }
                    else if (col == 0)
                    {
                        if (matrix[row - 1][col] > 0)
                        {

                            matrix[row - 1][col] -= bombValue;
                        }

                        if (matrix[row + 1][col] > 0)
                        {

                            matrix[row + 1][col] -= bombValue;
                        }

                        if (matrix[row - 1][col + 1] > 0)
                        {
                            matrix[row - 1][col + 1] -= bombValue;
                        }

                        if (matrix[row + 1][col + 1] > 0)
                        {
                            matrix[row + 1][col + 1] -= bombValue;
                        }

                    }
                    else
                    {
                        if (matrix[row - 1][col + 1] > 0)
                        {

                            matrix[row - 1][col + 1] -= bombValue;
                        }

                        if (matrix[row - 1][col - 1] > 0)
                        {

                            matrix[row - 1][col - 1] -= bombValue;
                        }

                        if (matrix[row - 1][col] > 0)
                        {
                            matrix[row - 1][col] -= bombValue;

                        }

                        if (matrix[row][col + 1] > 0)
                        {

                            matrix[row][col + 1] -= bombValue;
                        }

                        if (matrix[row][col - 1] > 0)
                        {

                            matrix[row][col - 1] -= bombValue;
                        }

                        if (matrix[row + 1][col + 1] > 0)
                        {

                            matrix[row + 1][col + 1] -= bombValue;
                        }

                        if (matrix[row + 1][col - 1] > 0)
                        {

                            matrix[row + 1][col - 1] -= bombValue;
                        }

                        if (matrix[row + 1][col] > 0)
                        {

                            matrix[row + 1][col] -= bombValue;
                        }
                    }

                }
            }

            var counter = 0;
            var sum = 0;
            foreach (var row in matrix)
            {
                foreach (var digit in row)
                {
                    if (digit > 0)
                    {
                        sum += digit;
                        counter++;
                    }

                }

            }

            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");

            //print result 
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
