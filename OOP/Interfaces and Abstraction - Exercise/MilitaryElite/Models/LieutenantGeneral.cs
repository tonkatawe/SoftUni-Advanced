using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id, salary)
        {
            this.privates = new List<Private>();
        }

        public int[] Proba { get; }

        public IReadOnlyList<IPrivate> Privates
        {
            get => this.privates;

        }

        public void AddPrivate(Private member)
        {
            this.privates.Add(member);
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            result.AppendLine("Privates:");
            foreach (var member in this.privates)
            {
                result.AppendLine($"  {member.ToString()}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
