namespace SantaWorkshop.Models.Presents
{
    using System;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Utilities.Messages;
    public class Present : IPresent
    {
        private string name;
        private int energyRequired;
        private const int DecreaseRequiredEnergyByCrafting = 10;
        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energyRequired = value;
            }
        }
        public void GetCrafted() => this.EnergyRequired -= DecreaseRequiredEnergyByCrafting;
        public bool IsDone() => this.EnergyRequired == 0;

    }
}
