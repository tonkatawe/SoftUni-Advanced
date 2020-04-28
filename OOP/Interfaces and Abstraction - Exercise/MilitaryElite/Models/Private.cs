using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;
        public Private(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }
        public decimal Salary
        {
            get => this.salary;
            private set { this.salary = value; }
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
        }
    }
}
