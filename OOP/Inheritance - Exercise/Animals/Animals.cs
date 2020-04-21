using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animals
    {
     //   private List<Animals> animals;
        private string name;
        private int age;
        private string gender;

        //private Animals()
        //{
        //    this.animals = new List<Animals>();
        //}
        public Animals(string name, int age, string gender)
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
                if (value == null)
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
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine();
        }

      
    }
}
