using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stat stats;

        public Player(string name, Stat stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Stat Stats { get; }
    }
}
