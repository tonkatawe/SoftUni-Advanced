namespace SantaWorkshop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new HashSet<IPresent>();
        }
        public IReadOnlyCollection<IPresent> Models { get => this.models.ToList().AsReadOnly(); }
        public void Add(IPresent model) => this.models.Add(model);

        public bool Remove(IPresent model) => this.models.Remove(model);

        public IPresent FindByName(string name) => this.Models.FirstOrDefault(x => x.Name == name);
    }
}
