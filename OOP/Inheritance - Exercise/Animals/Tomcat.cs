using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomcatGender = "Male";
        public Tomcat(string name, int age, string gender)
        : base(name, age, gender)
        {

        }

        public override string Gender
        {
            get
            {
                return TomcatGender;
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
