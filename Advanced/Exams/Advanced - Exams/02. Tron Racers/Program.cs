using System;
using System.Collections.Generic;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var firstPlayerRow = 0;
            var firstPlayerCol = 0;
            var secondPlayerRow = 0;
            var secondPlayrCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayrCol = col;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split();
                var playerOne = command[0];
                var playerTwo = command[1];
                if (playerOne == "down")
                {
                    if (firstPlayerRow + 1 < n)
                    {
                        firstPlayerRow++;
                    }
                    else
                    {
                        firstPlayerRow = 0;
                    }

                    if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                }
                else if (playerOne == "up")
                {
                    if (firstPlayerRow - 1 >= 0)
                    {
                        firstPlayerRow--;
                    }
                    else
                    {
                        firstPlayerRow = n - 1;
                    }

                    if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                }
                else if (playerOne == "left")
                {
                    if (firstPlayerCol - 1 >= 0)
                    {
                        firstPlayerCol--;
                    }
                    else
                    {
                        firstPlayerCol = n - 1;
                    }

                    if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                }
                else if (playerOne == "right")
                {
                    if (firstPlayerCol + 1 < n)
                    {
                        firstPlayerCol++;
                    }
                    else
                    {
                        firstPlayerCol = 0;
                    }

                    if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                }
                /*-------------------------------------------------------------------------------------*/
                if (playerTwo == "down")
                {
                    if (secondPlayerRow + 1 < n)
                    {
                        secondPlayerRow++;
                    }
                    else
                    {
                        secondPlayerRow = 0;
                    }

                    if (matrix[secondPlayerRow, secondPlayrCol] == 'f')
                    {
                        matrix[secondPlayerRow, secondPlayrCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[secondPlayerRow, secondPlayrCol] = 's';
                    }
                }
                else if (playerTwo == "up")
                {
                    if (secondPlayerRow - 1 >= 0)
                    {
                        secondPlayerRow--;
                    }
                    else
                    {
                        secondPlayerRow = n - 1;
                    }

                    if (matrix[secondPlayerRow, secondPlayrCol] == 'f')
                    {
                        matrix[secondPlayerRow, secondPlayrCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[secondPlayerRow, secondPlayrCol] = 's';
                    }
                }
                else if (playerTwo == "left")
                {
                    if (secondPlayrCol - 1 >= 0)
                    {
                        secondPlayrCol--;
                    }
                    else
                    {
                        secondPlayrCol = n - 1;
                    }

                    if (matrix[secondPlayerRow, secondPlayrCol] == 'f')
                    {
                        matrix[secondPlayerRow, secondPlayrCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[secondPlayerRow, secondPlayrCol] = 's';
                    }
                }
                else if (playerTwo == "right")
                {
                    if (secondPlayrCol + 1 < n)
                    {
                        secondPlayrCol++;
                    }
                    else
                    {
                        secondPlayrCol = 0;
                    }

                    if (matrix[secondPlayerRow, secondPlayrCol] == 'f')
                    {
                        matrix[secondPlayerRow, secondPlayrCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[secondPlayerRow, secondPlayrCol] = 's';
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
