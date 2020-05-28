
namespace SpaceStation.Models.Astronauts
{
    using System;
    using SpaceStation.Utilities.Messages;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    public abstract class Astronaut : IAstronaut
    {
        private const double DecreaseOxygenByBreath = 10;
        private string name;
        private double oxygen;
        private IBag bag;
        private bool canBreath;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();

        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);

                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag => this.bag;
        public virtual void Breath()
        {
            this.Oxygen -= DecreaseOxygenByBreath;
            if (this.Oxygen <0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
