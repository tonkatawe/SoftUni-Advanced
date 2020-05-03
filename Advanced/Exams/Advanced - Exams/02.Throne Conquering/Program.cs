using System;

namespace _02.Throne_Conquering
{
    class Program
    {
        static void Main(string[] args)
        {
            var energyOfParis = int.Parse(Console.ReadLine());
            var size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            var colParis = 0;
            var rowParis = 0;
            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                matrix[row] = currentRow;
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];
                    if (currentRow[col] == 'P')
                    {
                        colParis = col;
                        rowParis = row;
                    }
                }
            }

            while (true)
            {
                var currentCommand = Console.ReadLine().Split();
                var direction = currentCommand[0];
                var curRow = int.Parse(currentCommand[1]);
                var curCol = int.Parse(currentCommand[2]);
                matrix[curRow][curCol] = 'S';
                energyOfParis -= 1;

                if (direction == "up")
                {
                    if (rowParis - 1 >= 0)
                    {
                        rowParis--;
                        matrix[rowParis + 1][colParis] = '-';
                        if (matrix[rowParis][colParis] == 'S')
                        {
                            energyOfParis -= 2;
                        }
                        else if (matrix[rowParis][colParis] == 'H')
                        {
                            Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {energyOfParis}");
                            matrix[rowParis][colParis] = '-';
                            break;
                        }
                    }
                }
                else if (direction == "down")
                {
                    if (rowParis + 1 < size)
                    {
                        rowParis++;
                        matrix[rowParis - 1][colParis] = '-';
                        if (matrix[rowParis][colParis] == 'S')
                        {
                            energyOfParis -= 2;
                        }
                        else if (matrix[rowParis][colParis] == 'H')
                        {
                            Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {energyOfParis}");
                            matrix[rowParis][colParis] = '-';
                            break;
                        }
                    }
                }
                else if (direction == "left")
                {
                    if (colParis - 1 >= 0)
                    {
                        colParis--;
                        matrix[rowParis][colParis + 1] = '-';
                        if (matrix[rowParis][colParis] == 'S')
                        {
                            energyOfParis -= 2;
                        }
                        else if (matrix[rowParis][colParis] == 'H')
                        {
                            Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {energyOfParis}");
                            matrix[rowParis][colParis] = '-';
                            break;
                        }
                    }
                }
                else if (direction == "right")
                {
                    if (colParis + 1 < size)
                    {
                        colParis++;
                        matrix[rowParis][colParis - 1] = '-';
                        if (matrix[rowParis][colParis] == 'S')
                        {
                            energyOfParis -= 2;
                        }
                        else if (matrix[rowParis][colParis] == 'H')
                        {
                            Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {energyOfParis}");
                            matrix[rowParis][colParis] = '-';
                            break;
                        }
                    }
                }
                if (energyOfParis <= 0)
                {
                    matrix[rowParis][colParis] = 'X';
                    Console.WriteLine($"Paris died at {rowParis};{colParis}.");
                    break;
                }


            }

            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }

    }
}
