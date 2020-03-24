using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsNumber = int.Parse(Console.ReadLine());
            var studentsAndGrates = new Dictionary<string, List<double>>();
            for (int i = 0; i < studentsNumber; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = input[0];
                var grade = double.Parse(input[1]);
                if (grade >= 2)
                {


                    if (!studentsAndGrates.ContainsKey(name))
                    {
                        studentsAndGrates.Add(name, new List<double>());

                    }
                    studentsAndGrates[name].Add(grade);


                }
            }

            foreach (var student in studentsAndGrates)
            {
                var name = student.Key;
                var grades = student.Value;
                var avr = student.Value.Average();
                Console.Write($"{name} -> ");
                foreach (var grade in grades)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {avr:F2})");
            }
        }
    }
}
