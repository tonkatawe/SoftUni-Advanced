using System;
using System.Linq;
using System.Collections.Generic;

namespace _02HelensAbduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] jagged = new char[rows][];

            int parisRow = 0;
            int parisCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                jagged[row] = new char[input.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = input[col];

                    if (jagged[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string move = command[0];
                int spartanRow = int.Parse(command[1]);
                int spartanCol = int.Parse(command[2]);

                jagged[spartanRow][spartanCol] = 'S';

                if (move == "up")
                {
                    if (parisRow - 1 >= 0)
                    {
                        jagged[parisRow][parisCol] = '-';
                        energy -= 1;
                        parisRow -= 1;

                        if (jagged[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;

                            if (energy <= 0)
                            {
                                jagged[parisRow][parisCol] = 'X';
                                Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                                break;
                            }
                        }
                        else if (jagged[parisRow][parisCol] == 'H')
                        {
                            jagged[parisRow][parisCol] = '-';
                            Console.WriteLine("Paris has successfully sat on the throne! Energy left: {0}", energy);
                            break;
                        }

                        if (energy <= 0)
                        {
                            jagged[parisRow][parisCol] = 'X';
                            Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                            break;
                        }
                    }
                    else
                    {
                        energy -= 1;

                        if (energy <= 0)
                        {
                            jagged[parisRow][parisCol] = 'X';
                            Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                            break;
                        }
                    }
                }
                else if (move == "down")
                {
                    if (parisRow + 1 < rows)
                    {
                        jagged[parisRow][parisCol] = '-';
                        energy -= 1;
                        parisRow += 1;

                        if (jagged[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;

                            if (energy <= 0)
                            {
                                jagged[parisRow][parisCol] = 'X';
                                Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                                break;
                            }
                        }
                        else if (jagged[parisRow][parisCol] == 'H')
                        {
                            jagged[parisRow][parisCol] = '-';
                            Console.WriteLine("Paris has successfully sat on the throne! Energy left: {0}", energy);
                            break;
                        }

                        if (energy <= 0)
                        {
                            jagged[parisRow][parisCol] = 'X';
                            Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                            break;
                        }
                    }
                    else
                    {
                        energy -= 1;

                        if (energy <= 0)
                        {
                            jagged[parisRow][parisCol] = 'X';
                            Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                            break;
                        }
                    }
                }
                else if (move == "left")
                {
                    if (parisCol - 1 >= 0)
                    {
                        jagged[parisRow][parisCol] = '-';
                        energy -= 1;
                        parisCol -= 1;

                        if (jagged[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;

                            if (energy <= 0)
                            {
                                jagged[parisRow][parisCol] = 'X';
                                Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                                break;
                            }
                        }
                        else if (jagged[parisRow][parisCol] == 'H')
                        {
                            jagged[parisRow][parisCol] = '-';
                            Console.WriteLine("Paris has successfully sat on the throne! Energy left: {0}", energy);
                            break;
                        }

                        if (energy <= 0)
                        {
                            jagged[parisRow][parisCol] = 'X';
                            Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                            break;
                        }
                    }
                    else
                    {
                        energy -= 1;

                        if (energy <= 0)
                        {
                            jagged[parisRow][parisCol] = 'X';
                            Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                            break;
                        }
                    }
                }
                else if (move == "right")
                {
                    if (parisCol + 1 < jagged[parisRow].Length)
                    {
                        jagged[parisRow][parisCol] = '-';
                        energy -= 1;
                        parisCol += 1;

                        if (jagged[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;

                            if (energy <= 0)
                            {
                                jagged[parisRow][parisCol] = 'X';
                                Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                                break;
                            }
                        }
                        else if (jagged[parisRow][parisCol] == 'H')
                        {
                            jagged[parisRow][parisCol] = '-';
                            Console.WriteLine("Paris has successfully sat on the throne! Energy left: {0}", energy);
                            break;
                        }

                        if (energy <= 0)
                        {
                            jagged[parisRow][parisCol] = 'X';
                            Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                            break;
                        }
                    }
                    else
                    {
                        energy -= 1;

                        if (energy <= 0)
                        {
                            jagged[parisRow][parisCol] = 'X';
                            Console.WriteLine("Paris died at {0};{1}.", parisRow, parisCol);
                            break;
                        }
                    }
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(row);
            }
        }
    }
}