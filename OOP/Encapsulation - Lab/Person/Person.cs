using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }
        public string FirstName
        {
            get { return this.firstName; }
             set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                value = this.firstName;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
             set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                value = this.lastName;
            }
        }

        public int Age
        {
            get { return this.age; }
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                value = this.age;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
             set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                value = this.salary;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {

            if (this.Age < 30)
            {
                percentage /= 2;
            }

            this.Salary *= (1 + percentage / 100);
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
    }
}
