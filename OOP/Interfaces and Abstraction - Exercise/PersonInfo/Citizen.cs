using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string bitrhdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = bitrhdate;
            this.Id = id;
        }
        public string Name { get; }
        public int Age { get; }
        public string Birthdate { get; }
        public string Id { get; }
    }
}
