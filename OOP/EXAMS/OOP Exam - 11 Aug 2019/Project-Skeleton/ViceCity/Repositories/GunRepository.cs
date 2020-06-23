
namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;
    class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;
        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();
        public void Add(IGun model) => this.models.Add(model);

        public bool Remove(IGun model) => this.models.Remove(model);

        public IGun Find(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}
