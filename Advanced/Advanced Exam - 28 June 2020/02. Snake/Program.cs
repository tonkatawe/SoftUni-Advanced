using System;
using System.Collections.Generic;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var row = 0;
            var col = 0;
            var food = 0;

            var data = new Queue<Tuple<int, int>>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var current = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = current[j];
                    if (current[j] == 'S')
                    {
                        row = i;
                        col = j;
                    }

                    if (current[j] == 'B')
                    {
                        data.Enqueue(new Tuple<int, int>(i, j));
                    }
                }
            }

            while (true)
            {
                if (food >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    Console.WriteLine($"Food eaten: {food}");
                 //   matrix[row, col] = 'S';
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]}");
                        }

                        Console.WriteLine();
                    }
                    return;

                }
                var path = Console.ReadLine();

                if (path == "up" && row - 1 >= 0)
                {
                    matrix[row, col] = '.';
                    row--;
                    if (matrix[row, col] == '*')
                    {
                        food++;
                       // matrix[row, col] = '.';
                    }

                    if (matrix[row, col] == 'B')
                    {
                        matrix[row, col] = '.';
                        data.Dequeue();
                        var newrow = data.Dequeue();
                        matrix[row, col] = '.';
                        row = newrow.Item1;
                        col = newrow.Item2;
                        matrix[row, col] = '.';

                    }
                    matrix[row, col] = 'S';
                }
                else if (path == "down" && row+1 < n )
                {
                    matrix[row, col] = '.';
                    row++;
                    if (matrix[row, col] == '*')
                    {
                        food++;
              //          matrix[row, col] = '.';
                    }

                    if (matrix[row, col] == 'B')
                    {
                        matrix[row, col] = '.';
                        data.Dequeue();
                        var newrow = data.Dequeue();
                        matrix[row, col] = '.';
                        row = newrow.Item1;
                        col = newrow.Item2;
                        matrix[row, col] = '.';
                    }
                    matrix[row, col] = 'S';
                }
                else if (path == "left" && col-1 >= 0)
                {
                    matrix[row, col] = '.';
                    col--;
                    if (matrix[row, col] == '*')
                    {
                        food++;
                    //    matrix[row, col] = '.';
                    }

                    if (matrix[row, col] == 'B')
                    {
                        matrix[row, col] = '.';
                        data.Dequeue();
                        var newrow = data.Dequeue();
                        matrix[row, col] = '.';
                        row = newrow.Item1;
                        col = newrow.Item2;
                        matrix[row, col] = '.';
                    }
                    matrix[row, col] = 'S';
                }
                else if (path == "right" && col+1 < n )
                {
                    matrix[row, col] = '.';
                    col++;
                    if (matrix[row, col] == '*')
                    {
                        food++;
                   //     matrix[row, col] = '.';
                    }

                    if (matrix[row, col] == 'B')
                    {
                        matrix[row, col] = '.';
                        data.Dequeue();
                        var newrow = data.Dequeue();
                        matrix[row, col] = '.';
                        row = newrow.Item1;
                        col = newrow.Item2;
                        matrix[row, col] = '.';
                    }
                    matrix[row, col] = 'S';
                }
                else
                {
                    matrix[row, col] = '.';
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {food}");
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]}");
                        }

                        Console.WriteLine();
                    }
                    return;

                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }

                Console.WriteLine();
            }
        }
    }
}
