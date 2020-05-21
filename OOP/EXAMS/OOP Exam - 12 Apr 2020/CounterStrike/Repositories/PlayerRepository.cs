using System.Linq;

namespace CounterStrike.Repositories
{

    using System;
    using CounterStrike.Utilities.Messages;
    using System.Collections.Generic;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories.Contracts;
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models { get => this.models.AsReadOnly(); }
        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(IPlayer model) => this.models.Remove(model);

        public IPlayer FindByName(string name) => this.models.FirstOrDefault(x => x.Username == name);
    }
}
