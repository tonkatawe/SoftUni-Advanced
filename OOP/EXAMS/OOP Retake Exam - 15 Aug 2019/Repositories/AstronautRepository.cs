namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly HashSet<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new HashSet<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => this.models.ToList().AsReadOnly();

        public void Add(IAstronaut model) => this.models.Add(model);

        public bool Remove(IAstronaut model) => this.models.Remove(model);

        public IAstronaut FindByName(string name) => this.models.FirstOrDefault(n => n.Name == name);
    }
}
