using System;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;

namespace _02._Re_Volt
{
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
                    rowCurr++;
                    if (IsInOutOfBounder(matrix, rowCurr))
                    {
                        rowCurr = matrix.GetLength(0) - 1;
                    }
                    if (IsBonus(matrix, rowCurr, colCurr))
                    {
                        rowCurr++;
                   
                        if (IsInOutOfBounder(matrix, rowCurr))
                        {
                            rowCurr = matrix.GetLength(0) - 1;
                        }
                    }
                    if (IsTrap(matrix, rowCurr, colCurr))
                    {
                        rowCurr--;
                        if (IsInOutOfBounder(matrix, rowCurr))
                        {
                            rowCurr = matrix.GetLength(0) - 1;
                        }
                    }
                    if (IsFinish(matrix, rowCurr, colCurr))
                    {
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                if (command == "up")
                {
                    matrix[rowCurr, colCurr] = '-';
                    rowCurr--;
                    if (IsInOutOfBounder(matrix, rowCurr))
                    {
                        rowCurr = matrix.GetLength(0) - 1;
                    }
                    if (IsBonus(matrix, rowCurr, colCurr))
                    {
                        rowCurr--;
                        if (IsInOutOfBounder(matrix, rowCurr))
                        {
                            rowCurr = matrix.GetLength(0) - 1;
                        }
                    }
                    if (IsTrap(matrix, rowCurr, colCurr))
                    {
                        rowCurr--;
                        if (IsInOutOfBounder(matrix, rowCurr))
                        {
                            rowCurr = matrix.GetLength(0) - 1;
                        }
                    }
                    if (IsFinish(matrix, rowCurr, colCurr))
                    {
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                if (command == "left")
                {
                    matrix[rowCurr, colCurr] = '-';
                    colCurr--;
                    if (IsInOutOfBounder(matrix, rowCurr))
                    {
                        colCurr = matrix.GetLength(1) - 1;
                    }
                    if (IsBonus(matrix, rowCurr, colCurr))
                    {
                        colCurr--;
                        if (IsInOutOfBounder(matrix, colCurr))
                        {
                            colCurr = matrix.GetLength(1) - 1;
                        }

                    }
                    if (IsTrap(matrix, rowCurr, colCurr))
                    {
                        colCurr--;
                        if (IsInOutOfBounder(matrix, colCurr))
                        {
                            colCurr = matrix.GetLength(1) - 1;
                        }
                    }
                    if (IsFinish(matrix, rowCurr, colCurr))
                    {
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                if (command == "right")
                {
                    matrix[rowCurr, colCurr] = '-';
                    colCurr++;
                    if (IsInOutOfBounder(matrix, rowCurr))
                    {
                        colCurr = matrix.GetLength(1) - 1;
                    }
                    if (IsBonus(matrix, rowCurr, colCurr))
                    {
                        colCurr++;
                        if (IsInOutOfBounder(matrix, colCurr))
                        {
                            colCurr = matrix.GetLength(1) - 1;
                        }
                    }
                    if (IsTrap(matrix, rowCurr, colCurr))
                    {
                        colCurr--;
                        if (IsInOutOfBounder(matrix, colCurr))
                        {
                            colCurr = matrix.GetLength(1) - 1;
                        }
                    }
                    if (IsFinish(matrix, rowCurr, colCurr))
                    {
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                }
            }

            Console.WriteLine("Player lost!");
            matrix[rowCurr, colCurr] = 'f';
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

        public static bool IsInOutOfBounder(char[,] matrix, int n)
        {
            if (n > matrix.GetLength(0) - 1 || n < 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsBonus(char[,] matrix, int rowStart, int colStart)
        {
            if (matrix[rowStart, colStart] == 'B')
            {
                matrix[rowStart, colStart] = 'B';
                return true;
            }
            return false;
        }

        public static bool IsFinish(char[,] matrix, int rowStart, int colStart)
        {
            if (matrix[rowStart, colStart] == 'F')
            {
                matrix[rowStart, colStart] = 'f';
                return true;
            }
            return false;

        }

        public static bool IsTrap(char[,] matrix, int rowStart, int colStart)
        {
            if (matrix[rowStart, colStart] == 'T')
            {
                matrix[rowStart, colStart] = 'T';
                return true;
            }

            return false;
        }
    }
}
