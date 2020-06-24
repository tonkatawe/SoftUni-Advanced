using System;
using System.Linq;

class Program
{
   

    static void Main()
    {
        var nums = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToList();

        long seqLength = nums.Count;
        long maxLength = 0;
        //var visitedNodes = new HashSet<long>(); - you do not need it!

        for (int step = 1; step < seqLength; step++)
        {
            for (int stNode = 0; stNode < seqLength; stNode++)
            {
                var localMax = 1;

                var currentElementIndex = stNode;
                var nextElementIndex = (currentElementIndex + step) % nums.Count;

                while (nums[nextElementIndex] > nums[currentElementIndex])
                {
                    localMax++;

                    currentElementIndex = nextElementIndex;
                    nextElementIndex = (currentElementIndex + step) % nums.Count;
                }

                if (maxLength < localMax)
                {
                    maxLength = localMax;
                }
            }
        }

        Console.WriteLine(maxLength);
   
    }
}