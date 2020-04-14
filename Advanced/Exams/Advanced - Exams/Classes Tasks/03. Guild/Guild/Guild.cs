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
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.players = new List<Player>(); //here might be have to implement capacity in this list 
            this.Count++;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get; set; }
        public void AddPlayer(Player player)
        {
            if (players.Count < this.Capacity && !players.Any(x => x.Name == player.Name))
            {
                this.players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            foreach (var player in this.players)
            {
                if (player.Name == name)
                {
                    this.players.Remove(player);
                    return true;
                    this.Count++;
                }
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            foreach (var player in this.players.Where(x =>x.Name == name))
            {
                if (player.Name == name && player.Rank != "Member") //here migh be checked and use return method for first name;
                {
                    player.Rank = "Member";
                    break;
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var player in this.players.Where(x=> x.Name == name))
            {
                if (player.Name == name && player.Rank != "Trial") //here migh be checked and use return method for first name;
                {
                    player.Rank = "Trial";
                    break;
                }
            }
        }
        public Player[] KickPlayersByClass(string classtype)
        {
            var currentList = new List<Player>();
            for (int i = 0; i < this.players.Count; i++)
            {

                if (this.players[i].Class == classtype)
                {
                    currentList.Add(this.players[i]);
                    this.players.Remove(this.players[i]);
                }
            }

            return currentList.ToArray();
        }

        public void Report()
        {
            Console.WriteLine($"Players in the guild: {this.Name}");
            foreach (var player in this.players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
