

namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;

    using System.Collections.Generic;
    using System.Linq;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Riders;
    using MXGP.Repositories.Contracts;
    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }
        public IRider GetByName(string name)
        {
            IRider currentMotorcycle = this.riders.FirstOrDefault(x => x.Name == name);
            return currentMotorcycle;
        }

        public IReadOnlyCollection<IRider> GetAll() => this.riders;


        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public bool Remove(IRider model)
        {
            return this.riders.Remove(model);
        }
    }
}
