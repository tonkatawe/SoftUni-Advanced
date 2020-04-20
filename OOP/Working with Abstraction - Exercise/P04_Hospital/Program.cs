using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Output")
                {
                    break;
                }
                var tokens = command.Split();
                var department = tokens[0];
                var firstName = tokens[1];
                var surName = tokens[2];
                var patient = tokens[3];
                var doctorName = firstName + surName;

                if (!doctors.ContainsKey(doctorName))
                {
                    doctors[doctorName] = new List<string>();
                }
                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        departments[department].Add(new List<string>());
                    }
                }

                bool isHasRoom = departments[department].SelectMany(x => x).Count() < 60;
                if (isHasRoom)
                {
                    var rooms = 0;
                    doctors[doctorName].Add(patient);
                    for (int room = 0; room < departments[department].Count; room++)
                    {
                        if (departments[department][room].Count < 3)
                        {
                            rooms = room;
                            break;
                        }
                    }
                    departments[department][rooms].Add(patient);
                }
            }


            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                var arguments = command.Split();

                if (arguments.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[arguments[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (arguments.Length == 2 && int.TryParse(arguments[1], out int staq))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[arguments[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doctors[arguments[0] + arguments[1]].OrderBy(x => x)));
                }
            }
        }
    }
}
