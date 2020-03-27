using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace _05._Filter_By_Age
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = line[0];
                var age = int.Parse(line[1]);
                var person = new Person(name, age);
                people.Add(person);
            }

            var filterCommand = Console.ReadLine();
            var ages = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            Func<Person, bool> predicate = p => true;
            if (filterCommand == "older")
            {
                predicate = p => p.Age >= ages;
            }
            else if (filterCommand == "younger")
            {
                predicate = p => p.Age <= ages;
            }

            var filteredPeople = people.Where(predicate);

            foreach (var person in filteredPeople)
            {
                if (format == "name age")
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
                else if (format == "name")
                {
                    Console.WriteLine($"{person.Name}");
                }
                else if (format == "age")
                {
                    Console.WriteLine($"{person.Age}");
                }
            }
        }

    }
}
