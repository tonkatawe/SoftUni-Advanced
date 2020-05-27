

namespace SpaceStation.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly HashSet<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new HashSet<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.models.ToList().AsReadOnly();
        public void Add(IPlanet model) => this.models.Add(model);

        public bool Remove(IPlanet model) => this.models.Remove(model);

        public IPlanet FindByName(string name) => this.models.FirstOrDefault(n => n.Name == name);
    }
}
