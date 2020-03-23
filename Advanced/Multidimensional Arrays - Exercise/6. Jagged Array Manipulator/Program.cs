using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //87/100 have to check!!!!
            var rows = int.Parse(Console.ReadLine());
            if (rows >= 2 && rows <= 12)
            {

                int[][] jaggedArr = new int[rows][];

                for (int row = 0; row < jaggedArr.Length; row++)
                {
                    jaggedArr[row] = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                }


                // multiply all elements in equal rows
                for (int row = 0; row < jaggedArr.Length - 1; row++)
                {
                    if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                    {
                        for (int col = 0; col < jaggedArr[row].Length; col++)
                        {
                            jaggedArr[row][col] *= 2;
                            jaggedArr[row + 1][col] *= 2;
                        }
                    }
                    else if (jaggedArr[row].Length != jaggedArr[row + 1].Length)
                    {
                        var length =
                            Math.Max(jaggedArr[row].Length, jaggedArr[row + 1].Length); //have to count to longer row
                        //divide all elements in current row because there both with different length
                        for (int col = 0; col < length; col++)
                        {
                            if (col < jaggedArr[row].Length && col < jaggedArr[row + 1].Length)
                            {
                                jaggedArr[row][col] /= 2;
                                jaggedArr[row + 1][col] /= 2;
                            }
                            else if (col < jaggedArr[row].Length)
                            {
                                jaggedArr[row][col] /= 2;
                            }
                            else if (col < jaggedArr[row + 1].Length)
                            {
                                jaggedArr[row + 1][col] /= 2;
                            }

                        }

                    }
                }

                while (true)
                {
                    var command = Console.ReadLine();
                    if (command == "End")
                    {
                        break;
                    }

                    var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var instructions = tokens[0];
                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var value = int.Parse(tokens[3]);
                    if (row >= 0 && col >= 0 && row < jaggedArr.Length && col < jaggedArr[row].Length)
                    {
                        if (instructions == "Add")
                        {
                            jaggedArr[row][col] += value;
                        }
                        else if (instructions == "Subtract")
                        {
                            jaggedArr[row][col] -= value;
                        }
                    }
                }

                foreach (var row in jaggedArr)
                {
                    string[] newArr = row.Select(x => x.ToString()).ToArray();
                    Console.WriteLine(string.Join(" ", newArr));
                }
            }
        }
    }
}
