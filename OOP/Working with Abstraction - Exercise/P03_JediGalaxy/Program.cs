using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Program
    {
        public static void Main()
        {
            var dimestions = ParseArrayFromConsole();
            var x = dimestions[0]; //its rows
            int y = dimestions[1]; //its columns

            var matrix = new int[x, y];

            var value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            long sum = 0;// might be change it
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Let the Force be with you")
                {
                    break;
                }
                var ivoStart = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var evilStart = ParseArrayFromConsole();
                var xE = evilStart[0];
                var yE = evilStart[1];

                while (xE >= 0 && yE >= 0)
                {
                    if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                    {
                        matrix[xE, yE] = 0;
                    }
                    xE--;
                    yE--;
                }

                var xI = ivoStart[0];
                var yI = ivoStart[1];

                while (xI >= 0 && yI < matrix.GetLength(1))
                {
                    if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                    {
                        sum += matrix[xI, yI];
                    }

                    yI++;
                    xI--;
                }
            }

            Console.WriteLine(sum);
        }

        public static int[] ParseArrayFromConsole()
        {
            return Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
