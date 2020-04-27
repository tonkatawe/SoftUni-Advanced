using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Schema;

namespace FootballTeamGenerator
{

    public class Team
    {

        private string name;
        private List<Player> players;


        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
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


        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            this.players.Remove(player);
        }
        public double Rating()
        {
            return this.players.Sum(x=> x.Stats.GetAverage()/players.Count);
        }
    }
}
