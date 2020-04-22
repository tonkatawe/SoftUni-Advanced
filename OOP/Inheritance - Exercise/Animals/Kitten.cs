using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string KittenGender = "Female";
        public Kitten(string name, int Age)
        : base(name, Age, KittenGender)
        {

        }

        public override string Gender
        {
            get
            {
                return KittenGender;
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
