using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string typeCorps;
        public SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string typeCorps)
            : base(firstName, lastName, id, salary)
        {
            this.TypeCorps = typeCorps;
        }

        public string TypeCorps
        {
            get => this.typeCorps;
            private set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.typeCorps = value;
                }
            }
        }
    }
}
