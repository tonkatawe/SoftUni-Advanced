using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace StudentInfo
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            var data = new StudentData();
            //StudentData studentSystem = new StudentData();
            while (true)
            {
                var command = input[0];
                if (command == "Exit")
                {
                    break;
                }
                if (command == "Create")
                {
                    var tokens = input
                        .Skip(1)
                        .ToArray();
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var grade = double.Parse(tokens[2]);
                    var student = new Student(name, age, grade);
                    data.CreateStudnet(student);

                }
                else if (command == "Show")
                {
                    var name = input[1];
                    Console.WriteLine(data.Show(name));


                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
