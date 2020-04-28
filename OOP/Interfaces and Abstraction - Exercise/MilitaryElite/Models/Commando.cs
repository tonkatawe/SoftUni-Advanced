using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;
        public Commando(string firstName, string lastName, int id, decimal salary, string typeCorps) : base(firstName, lastName, id, salary, typeCorps)
        {
            this.missions = new List<Mission>();
        }

        public IReadOnlyList<Mission> Missions
        {
            get => this.missions;

        }

        public void AddMission(Mission mission)
        {
            this.missions.Add(mission);

        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            result.AppendLine($"Corps: {this.TypeCorps}");

            result.AppendLine($"Missions:");
            foreach (var mission in missions.Where(x=>x.State == "inProgress"))
            {
                result.AppendLine($"  {mission.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
