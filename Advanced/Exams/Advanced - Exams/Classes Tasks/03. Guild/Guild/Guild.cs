using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;

        private Guild()
        {
            this.players = new List<Player>();
        }
        public Guild(string name, int capacity)
        : this()
        {
            this.Name = name;
            this.Capacity = capacity;

        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.players.Count;
        public void AddPlayer(Player player)
        {
            if (players.Count + 1 <= this.Capacity)
            {
                this.players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var player = this.players.FirstOrDefault(p => p.Name == name);
            if (player.Name != null)
            {
                this.players.Remove(player);
                return true;

            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var player = this.players.FirstOrDefault(p => p.Name == name && p.Rank != "Member");
            if (player != null)
            {
                player.Rank = "Member";
            }

        }

        public void DemotePlayer(string name)
        {
            var player = this.players.FirstOrDefault(p => p.Name == name && p.Rank != "Trial");
            if (player != null)
            {
                player.Rank = "Trial";
            }

        }
        public Player[] KickPlayersByClass(string classtype)
        {
            var players = this.players.Where(p => p.Class == classtype)
                .ToArray();
            this.players.RemoveAll(p => p.Class == classtype);
            return players;
        }

        public string Report()
        {
            var result = new StringBuilder();
            result.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.players)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
