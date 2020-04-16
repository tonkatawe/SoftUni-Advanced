using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        private Player()
        {

            this.Rank = "Trial";
            this.Description = "n/a";
        }
        public Player(string name, string classtype)
            : this()
        {
            this.Name = name;
            this.Class = classtype;
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Player {this.Name}: {this.Class}");
            result.AppendLine($"Rank: {this.Rank}");
            result.AppendLine($"Description: {this.Description}");
            return result.ToString().TrimEnd();
        }
    }
}
