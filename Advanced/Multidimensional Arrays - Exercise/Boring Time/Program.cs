using System;

namespace Boring_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            for (int i = 0; i < n; i++)
            {
               sum += i;
               if (sum >9)
               {
                  
               }
            }

            var result = sum + n;
            Console.WriteLine(sum);
        }
    }
}
