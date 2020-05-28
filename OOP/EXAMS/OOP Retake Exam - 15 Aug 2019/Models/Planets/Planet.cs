
namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using SpaceStation.Utilities.Messages;
    public class Planet : IPlanet
    {
        private string name;


        public Planet(string name)
        {
            this.Name = name;
            this.Items = new List<string>();
        }

        public ICollection<string> Items
        {
            get;
            private set;

        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }
    }
}
