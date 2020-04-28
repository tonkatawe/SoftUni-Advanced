using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {

        private List<Repair> repairs;
        public Engineer(string firstName, string lastName, int id, decimal salary, string typeCorps)
            : base(firstName, lastName, id, salary, typeCorps)
        {
            this.repairs = new List<Repair>();
        }
        public IReadOnlyList<Repair> Repairs { get; }

        public void AddRepair(Repair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            result.AppendLine($"Corps: {this.TypeCorps}");
            result.AppendLine($"Repairs:");
            foreach (var repair in repairs)
            {
                result.AppendLine($"  {repair.ToString()}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
