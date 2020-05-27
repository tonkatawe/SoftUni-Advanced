namespace SantaWorkshop.Models.Dwarfs
{
    using System;
    using System.Collections.Generic;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments.Contracts;
    using SantaWorkshop.Utilities.Messages;
    public abstract class Dwarf : IDwarf
    {
        private const int DecreaseByWork = 10;

        private string name;
        private int energy;
        private readonly ICollection<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.instruments = new List<IInstrument>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energy = value;

            }
        }

        public ICollection<IInstrument> Instruments { get => this.instruments; }
        public virtual void Work() => this.Energy -= DecreaseByWork;


        public void AddInstrument(IInstrument instrument) => this.instruments.Add(instrument);

    }
}
