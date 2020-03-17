using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowSize = int.Parse(Console.ReadLine());
            int[][] jagArr = new int[rowSize][];
            for (int row = 0; row < jagArr.GetLength(0); row++)
            {
                var currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jagArr[row] = currRow;

            }

            while (true)
            {
                var instruction = Console.ReadLine().ToLower();
                if (instruction == "end")
                {
                    break;
                }
                var tokens = instruction.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                instruction = tokens[0];
                var currRow = int.Parse(tokens[1]);
                var currCol = int.Parse(tokens[2]);
                var value = int.Parse(tokens[3]);
                if (currRow >= jagArr.Length || currCol >= jagArr.Length || currRow < 0 || currCol < 0)
                {
                    Console.WriteLine("Invalid coordinates");

                }
                else if (instruction == "add")
                {
                    jagArr[currRow][currCol] += value;
                }
                else if (instruction == "subtract")
                {
                    jagArr[currRow][currCol] -= value;
                }
            }

            foreach (var row in jagArr)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
