﻿using System.Collections.Generic;
using System.Linq;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
        {
            get => this.decorations.AsReadOnly();

        }
        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public bool Remove(IDecoration model) => this.decorations.Remove(model);

        public IDecoration FindByType(string type) => this.decorations.FirstOrDefault(x => x.GetType().Name == type);
    }
}
