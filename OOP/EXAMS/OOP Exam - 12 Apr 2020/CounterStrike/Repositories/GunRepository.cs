namespace CounterStrike.Repositories
{
    using System;
    using System.Linq;
    using CounterStrike.Utilities.Messages;
    using System.Collections.Generic;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Repositories.Contracts;
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models { get => this.models.AsReadOnly(); }
        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(IGun model) => this.models.Remove(model);

        public IGun FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}
