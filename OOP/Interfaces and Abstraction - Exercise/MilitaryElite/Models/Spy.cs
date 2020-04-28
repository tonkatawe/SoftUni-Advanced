using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, int id)
            : base(firstName, lastName, id)
        {
        }
        public int CodeNumberOfSpy { get; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            result.AppendLine($"Code Number: {this.CodeNumberOfSpy}");
            return result.ToString().TrimEnd();
        }
    }
}
