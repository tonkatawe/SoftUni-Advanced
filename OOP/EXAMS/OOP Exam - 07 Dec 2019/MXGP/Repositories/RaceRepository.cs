
namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Races;
    using MXGP.Repositories.Contracts;
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public IRace GetByName(string name)
        {
            var currentMotorcycle = this.races.FirstOrDefault(x => x.Name == name);
            return currentMotorcycle;
        }

        public IReadOnlyCollection<IRace> GetAll() => this.races;


        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }
    }
}
