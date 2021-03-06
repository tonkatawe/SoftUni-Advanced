﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Present_Delivery
{
    //here I have 83/100 
    class Program
    {
        static void Main(string[] args)
        {
            var m = int.Parse(Console.ReadLine());
            var countOfPresents = m;
            var n = int.Parse(Console.ReadLine()); //read size of square matrix
            var matrix = new string[n, n];
            //use next two variables to save Santa`s location
            var rowStart = 0;
            var colStart = 0;
            //make counter to save all nice kids
            var niceKidsCounter = 0;
            //make counter for all nice kids in the matrix
            var matrixNiceKids = 0;
            var naughtyKids = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == "S")
                    {
                        rowStart = row;
                        colStart = col;

                    }



                }
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (countOfPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }
                if (command == "Christmas morning")
                {
                    break;
                }
                //I am not sure but might be I have to make 'if' for matrix`s boundary per each movement. Firstly I`ll skip this.
                else if (command == "up")
                {
                    rowStart--;
                    matrix[rowStart + 1, colStart] = "-";
                    if (matrix[rowStart, colStart] == "X")
                    {
                        matrix[rowStart, colStart] = "S";
                    }
                    else if (matrix[rowStart, colStart] == "V")
                    {
                        matrix[rowStart, colStart] = "S";
                        niceKidsCounter++;
                        countOfPresents--;
                    }
                    else if (matrix[rowStart, colStart] == "C")
                    {
                        matrix[rowStart, colStart] = "S";
                        for (int i = 0; i < 4; i++)
                        {
                            if (matrix[rowStart + 1, colStart] == "X")
                            {
                                matrix[rowStart + 1, colStart] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart + 1, colStart] == "V")
                            {
                                matrix[rowStart + 1, colStart] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart - 1, colStart] == "X")
                            {
                                matrix[rowStart - 1, colStart] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart - 1, colStart] == "V")
                            {
                                matrix[rowStart - 1, colStart] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart, colStart + 1] == "X")
                            {
                                matrix[rowStart, colStart + 1] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart, colStart + 1] == "V")
                            {
                                matrix[rowStart, colStart + 1] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart, colStart - 1] == "X")
                            {
                                matrix[rowStart, colStart - 1] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart, colStart - 1] == "V")
                            {
                                matrix[rowStart, colStart - 1] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }

                            if (countOfPresents == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (command == "down")
                {
                    rowStart++;
                    //    matrix[rowStart, colStart] = "S";
                    matrix[rowStart - 1, colStart] = "-";
                    if (matrix[rowStart, colStart] == "X")
                    {
                        matrix[rowStart, colStart] = "S";
                    }
                    else if (matrix[rowStart, colStart] == "V")
                    {
                        matrix[rowStart, colStart] = "S";
                        countOfPresents--;
                        niceKidsCounter++;
                    }
                    else if (matrix[rowStart, colStart] == "C")
                    {
                        matrix[rowStart, colStart] = "S";
                        for (int i = 0; i < 4; i++)
                        {
                            if (matrix[rowStart + 1, colStart] == "X")
                            {
                                matrix[rowStart + 1, colStart] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart + 1, colStart] == "V")
                            {
                                matrix[rowStart + 1, colStart] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart - 1, colStart] == "X")
                            {
                                matrix[rowStart - 1, colStart] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart - 1, colStart] == "V")
                            {
                                matrix[rowStart - 1, colStart] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart, colStart + 1] == "X")
                            {
                                matrix[rowStart, colStart + 1] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart, colStart + 1] == "V")
                            {
                                matrix[rowStart, colStart + 1] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart, colStart - 1] == "X")
                            {
                                matrix[rowStart, colStart - 1] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart, colStart - 1] == "V")
                            {
                                matrix[rowStart, colStart - 1] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }

                            if (countOfPresents == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (command == "left")
                {
                    colStart--;
                    matrix[rowStart, colStart + 1] = "-";

                    if (matrix[rowStart, colStart] == "X")
                    {
                        matrix[rowStart, colStart] = "S";
                    }
                    else if (matrix[rowStart, colStart] == "V")
                    {
                        matrix[rowStart, colStart] = "S";
                        countOfPresents--;
                        niceKidsCounter++;
                    }
                    else if (matrix[rowStart, colStart] == "C")
                    {
                        matrix[rowStart, colStart] = "S";
                        for (int i = 0; i < 4; i++)
                        {
                            if (matrix[rowStart + 1, colStart] == "X")
                            {
                                matrix[rowStart + 1, colStart] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart + 1, colStart] == "V")
                            {
                                matrix[rowStart + 1, colStart] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart - 1, colStart] == "X")
                            {
                                matrix[rowStart - 1, colStart] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart - 1, colStart] == "V")
                            {
                                matrix[rowStart - 1, colStart] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart, colStart + 1] == "X")
                            {
                                matrix[rowStart, colStart + 1] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart, colStart + 1] == "V")
                            {
                                matrix[rowStart, colStart + 1] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart, colStart - 1] == "X")
                            {
                                matrix[rowStart, colStart - 1] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart, colStart - 1] == "V")
                            {
                                matrix[rowStart, colStart - 1] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }

                            if (countOfPresents == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (command == "right")
                {
                    colStart++;
                    matrix[rowStart, colStart - 1] = "-";
                    if (matrix[rowStart, colStart] == "X")
                    {
                        matrix[rowStart, colStart] = "S";
                    }
                    else if (matrix[rowStart, colStart] == "V")
                    {
                        matrix[rowStart, colStart] = "S";
                        countOfPresents--;
                        niceKidsCounter++;
                    }
                    else if (matrix[rowStart, colStart] == "C")
                    {
                        matrix[rowStart, colStart] = "S";
                        for (int i = 0; i < 4; i++)
                        {
                            if (matrix[rowStart + 1, colStart] == "X")
                            {
                                matrix[rowStart + 1, colStart] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart + 1, colStart] == "V")
                            {
                                matrix[rowStart + 1, colStart] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart - 1, colStart] == "X")
                            {
                                matrix[rowStart - 1, colStart] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart - 1, colStart] == "V")
                            {
                                matrix[rowStart - 1, colStart] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart, colStart + 1] == "X")
                            {
                                matrix[rowStart, colStart + 1] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart, colStart + 1] == "V")
                            {
                                matrix[rowStart, colStart + 1] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }
                            else if (matrix[rowStart, colStart - 1] == "X")
                            {
                                matrix[rowStart, colStart - 1] = "-";
                                countOfPresents--;
                            }
                            else if (matrix[rowStart, colStart - 1] == "V")
                            {
                                matrix[rowStart, colStart - 1] = "-";
                                countOfPresents--;
                                niceKidsCounter++;
                            }

                            if (countOfPresents == 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                    if (matrix[row, col] == "V")
                    {
                        matrixNiceKids++;
                    }
                }

                Console.WriteLine();
            }

            var resultKids = niceKidsCounter - matrixNiceKids;
            if (matrixNiceKids > 0)
            {
                Console.WriteLine($"No presents for {matrixNiceKids} nice kid/s.");
            }
            else
            {
                Console.WriteLine($"Good job, Santa! {niceKidsCounter} happy nice kid/s.");
            }
        }
    }
}
