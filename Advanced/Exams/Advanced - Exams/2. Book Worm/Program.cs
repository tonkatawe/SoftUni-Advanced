using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _2._Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = ReadCharArrFromConsole(); // use it to read word for tasks
            var word = new Stack<char>(m);
            var n = int.Parse(Console.ReadLine()); //read matrix`s size
            var matrix = new char[n, n];
            var rowCurr = 0; //use for currently row location
            var colCurr = 0; //use for currently col location
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = ReadCharArrFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'P')
                    {
                        rowCurr = row;
                        colCurr = col;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                else if (command == "up")
                {
                    if (rowCurr - 1 >= 0)
                    {
                        rowCurr--;
                        if (char.IsLetter(matrix[rowCurr, colCurr]))
                        {
                            word.Push(matrix[rowCurr, colCurr]);
                            matrix[rowCurr, colCurr] = 'P';
                            matrix[rowCurr + 1, colCurr] = '-';
                        }
                        else
                        {
                            matrix[rowCurr, colCurr] = 'P';
                            matrix[rowCurr + 1, colCurr] = '-';
                        }
                    }
                    else
                    {
                        if (word.Any())
                        {
                            word.Pop();
                        }
                    }
                }
                else if (command == "down")
                {
                    if (rowCurr + 1 < n)
                    {
                        rowCurr++;
                        if (char.IsLetter(matrix[rowCurr, colCurr]))
                        {
                            word.Push(matrix[rowCurr, colCurr]);
                            matrix[rowCurr, colCurr] = 'P';
                            matrix[rowCurr - 1, colCurr] = '-';
                        }
                        else
                        {
                            matrix[rowCurr, colCurr] = 'P';
                            matrix[rowCurr - 1, colCurr] = '-';
                        }
                    }
                    else
                    {
                        if (word.Any())
                        {
                            word.Pop();
                        }
                    }
                }
                else if (command == "left")
                {
                    if (colCurr - 1 >= 0)
                    {
                        colCurr--;
                        if (char.IsLetter(matrix[rowCurr, colCurr]))
                        {
                            word.Push(matrix[rowCurr, colCurr]);
                            matrix[rowCurr, colCurr] = 'P';
                            matrix[rowCurr, colCurr + 1] = '-';
                        }
                        else
                        {
                            matrix[rowCurr, colCurr] = 'P';
                            matrix[rowCurr, colCurr + 1] = '-';
                        }
                    }
                    else
                    {
                        if (word.Any())
                        {
                            word.Pop();
                        }
                    }
                }
                else if (command == "right")
                {
                    if (colCurr + 1 < n)
                    {
                        colCurr++;
                        if (char.IsLetter(matrix[rowCurr, colCurr]))
                        {
                            word.Push(matrix[rowCurr, colCurr]);
                            matrix[rowCurr, colCurr] = 'P';
                            matrix[rowCurr, colCurr - 1] = '-';
                        }
                        else
                        {
                            matrix[rowCurr, colCurr] = 'P';
                            matrix[rowCurr, colCurr - 1] = '-';
                        }
                    }
                    else
                    {
                        if (word.Any())
                        {
                            word.Pop();
                        }
                    }
                }
            }

            Console.WriteLine(string.Join("", word.Reverse()));
            PrintMatrx(matrix);
        }

        public static void PrintMatrx(char[,] matrix)
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
        public static char[] ReadCharArrFromConsole()
        {
            return Console.ReadLine().ToCharArray();
        }
    }
}
