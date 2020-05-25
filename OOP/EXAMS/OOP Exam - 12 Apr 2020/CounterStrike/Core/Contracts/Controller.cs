using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core.Contracts
{
    using CounterStrike.Models.Maps;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Repositories;
    using CounterStrike.Repositories.Contracts;
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;
        private List<IPlayer> livePlayers;


        public Controller()
        {
            this.livePlayers = new List<IPlayer>();
            this.players = new PlayerRepository();
            this.guns = new GunRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun;
            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            this.guns.Add(gun);
            var message = String.Format(OutputMessages.SuccessfullyAddedGun, name);
            return message;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player;
            IGun gun = this.guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            this.players.Add(player);
            var message = String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            return message;

        }

        public string StartGame()
        {
            livePlayers = this.players.Models.Where(p => p.IsAlive)
                .ToList();

            return this.map.Start(this.livePlayers);
        }

        public string Report()
        {
            var result = new StringBuilder();
            foreach (var player in this.players.Models.OrderBy(x=>x.GetType().Name).ThenByDescending(n=>n.Health).ThenBy(u=>u.Username))
            {
                result.AppendLine($"{player.GetType().Name}: {player.Username}");
                result.AppendLine($"--Health: {player.Health}");
                result.AppendLine($"--Armor: {player.Armor}");
                result.AppendLine($"--Gun: {player.Gun.Name}");

            }

            return result.ToString().TrimEnd();
        }
    }
}
