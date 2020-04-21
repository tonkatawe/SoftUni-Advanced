using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string KittenGender = "Female";
        public Kitten(string name, int Age, string gender)
        : base(name, Age, gender)
        {

        }

        public override string Gender
        {
            get
            {
                return KittenGender;
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
