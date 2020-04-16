using System;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;

namespace _02._Re_Volt
{
    //here my point is 90/100 :(

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); // use for matrix size
            var countOfCommands = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            var rowCurr = 0;
            var colCurr = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {

                        rowCurr = row;
                        colCurr = col;
                    }
                }
            }

            for (int i = 0; i < countOfCommands; i++)
            {
                var command = Console.ReadLine();

                if (command == "down")
                {
                    matrix[rowCurr, colCurr] = '-';
                    if (rowCurr + 1 < n)
                    {
                        rowCurr++;
                    }
                    else
                    {
                        rowCurr = 0;
                    }
                    if (matrix[rowCurr, colCurr] == 'B')
                    {
                        if (rowCurr + 1 < n)
                        {
                            rowCurr++;
                        }
                        else
                        {
                            rowCurr = 0;
                        }
                    }

                    if (matrix[rowCurr, colCurr] == 'T')
                    {
                        if (rowCurr - 1 >= 0)
                        {
                            rowCurr--;
                        }
                        else
                        {
                            rowCurr = n - 1;
                        }
                    }
                    if (matrix[rowCurr, colCurr] == 'F')
                    {
                        matrix[rowCurr, colCurr] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                    else
                    {
                        matrix[rowCurr, colCurr] = 'f';
                    }

                }
                if (command == "up")
                {
                    matrix[rowCurr, colCurr] = '-';
                    if (rowCurr - 1 >= 0)
                    {
                        rowCurr--;
                    }
                    else
                    {
                        rowCurr = n - 1;
                    }
                    if (matrix[rowCurr, colCurr] == 'B')
                    {
                        if (rowCurr - 1 >= 0)
                        {
                            rowCurr--;
                        }
                        else
                        {
                            rowCurr = n - 1;
                        }
                    }
                    if (matrix[rowCurr, colCurr] == 'T')
                    {
                        if (rowCurr - 1 >= 0)
                        {
                            rowCurr--;
                        }
                        else
                        {
                            rowCurr = n - 1;
                        }
                    }
                    if (matrix[rowCurr, colCurr] == 'F')
                    {
                        matrix[rowCurr, colCurr] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                    else
                    {
                        matrix[rowCurr, colCurr] = 'f';
                    }
                }
                if (command == "left")
                {
                    matrix[rowCurr, colCurr] = '-';
                    if (colCurr - 1 >= 0)
                    {
                        colCurr--;
                    }
                    else
                    {
                        colCurr = n - 1;
                    }
                    if (matrix[rowCurr, colCurr] == 'B')
                    {
                        if (colCurr - 1 >= 0)
                        {
                            colCurr--;
                        }
                        else
                        {
                            colCurr = n - 1;
                        }
                    }
                    if (matrix[rowCurr, colCurr] == 'T')
                    {
                        if (colCurr - 1 >= 0)
                        {
                            colCurr--;
                        }
                        else
                        {
                            colCurr = n - 1;
                        }
                    }

                    if (matrix[rowCurr, colCurr] == 'F')
                    {
                        matrix[rowCurr, colCurr] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                    else
                    {
                        matrix[rowCurr, colCurr] = 'f';
                    }
                }
                if (command == "right")
                {
                    matrix[rowCurr, colCurr] = '-';
                    if (colCurr + 1 < n)
                    {
                        colCurr++;
                    }
                    else
                    {
                        colCurr = 0;
                    }
                    if (matrix[rowCurr, colCurr] == 'B')
                    {
                        if (colCurr + 1 < n)
                        {
                            colCurr++;
                        }
                        else
                        {
                            colCurr = 0;
                        }
                    }
                    if (matrix[rowCurr, colCurr] == 'T')
                    {
                        if (colCurr - 1 >= 0)
                        {
                            colCurr--;
                        }
                        else
                        {
                            colCurr = n - 1;
                        }
                    }
                    if (matrix[rowCurr, colCurr] == 'F')
                    {
                        matrix[rowCurr, colCurr] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                    else
                    {
                        matrix[rowCurr, colCurr] = 'f';
                    }
                }
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        public static void PrintMatrix(char[,] matrix)
        {
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
