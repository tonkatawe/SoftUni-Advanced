


namespace CounterStrike.Models.Maps
{
    using CounterStrike.Models.Players;
    using System.Collections.Generic;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players.Contracts;
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            //todo:I am not sure for this method :)
            var terrorist = new List<IPlayer>();
            var counterTerrorists = new List<IPlayer>();

            foreach (IPlayer player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    terrorist.Add(player);
                }
                else if (player.GetType().Name == "CounterTerrorist")
                {
                    counterTerrorists.Add(player);
                }
            }

            if (terrorist.Count == 0)
            {
                return "Counter Terrorist wins!";
            }
            else
            {
                return "Terrorist wins!";
            }
        }
    }
}
