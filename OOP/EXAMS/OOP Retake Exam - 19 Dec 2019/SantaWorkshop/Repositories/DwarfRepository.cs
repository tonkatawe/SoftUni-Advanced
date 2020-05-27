namespace SantaWorkshop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Workshops.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new HashSet<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models { get => this.models.ToList().AsReadOnly(); }
        public void Add(IDwarf model) => this.models.Add(model);
        public bool Remove(IDwarf model) => this.models.Remove(model);

        public IDwarf FindByName(string name) => this.Models.FirstOrDefault(x => x.Name == name);
    }
}
