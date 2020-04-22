using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
   public class StartUp
    {
     public   static void Main(string[] args)
        {

            Team team = new Team("SoftUni");


            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var name = cmdArgs[0];
                var surName = cmdArgs[1];
                var age = int.Parse(cmdArgs[2]);
                var salary = decimal.Parse(cmdArgs[3]);
                var person = new Person(name, surName, age, salary);

                persons.Add(person);
            }
            //var parcentage = decimal.Parse(Console.ReadLine());
            //persons.ForEach(p => p.IncreaseSalary(parcentage));
           // persons.ForEach(p => Console.WriteLine(p.ToString()));
            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players");

        }
    }
}
