using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _5._Snake_Moves
{
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
            var snakeAsString = Console.ReadLine().ToCharArray();
            var snakeQue = new Queue<char>();
            var counter = 0;
            var pathCapacity = rows * cols;

            for (int i = 0; i < snakeAsString.Length; i++)
            {
                snakeQue.Enqueue(snakeAsString[i]);
                counter++;
                if (counter == pathCapacity)
                {
                    break;
                }

                if (i == snakeAsString.Length - 1)
                {
                    i = -1;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snakeQue.Dequeue();
                    }
                }
                else if (row % 2 != 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col > -1; col--)
                    {
                        matrix[row, col] = snakeQue.Dequeue();
                    }
                }
            }

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


