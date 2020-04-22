using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        //   private List<Animals> animals;
        private string name;
        private int age;
        private string gender;

        //private Animals()
        //{
        //    this.animals = new List<Animals>();
        //}
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;

            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public virtual string Gender
        {
            get
            {

                return this.gender;

            }
            protected set
            {
                if (String.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(this.GetType().Name);
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            result.AppendLine(this.ProduceSound());
            return result.ToString().TrimEnd();

        }

        public abstract string ProduceSound();
    }
}
