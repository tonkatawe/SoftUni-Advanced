
namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }
        public IMotorcycle GetByName(string name)
        {
            IMotorcycle currentMotorcycle = this.motorcycles.FirstOrDefault(x => x.Model == name);
            return currentMotorcycle;
        }

        public IReadOnlyCollection<IMotorcycle> GetAll() => this.motorcycles;


        public void Add(IMotorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public bool Remove(IMotorcycle model)
        {
            return this.motorcycles.Remove(model);
        }
    }
}
