using System;

namespace _1._Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            for (int stCount = 1; stCount <= size; stCount++)
            {
                PrintRow(size, stCount);
            }
            for (int stCount = size - 1; stCount >= 1; stCount--)
            {

                PrintRow(size, stCount);
            }
            
        }

        public static void PrintRow(int size, int count)
        {
            for (int i = 0; i < size - count; i++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < count; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");



        }
    }
}
