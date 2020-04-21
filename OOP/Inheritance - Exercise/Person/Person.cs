using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
   public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;

        }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(String.Format($"Name: {this.Name}, Age: {this.Age}"));
            return result.ToString().TrimEnd();
        }
    }
}
