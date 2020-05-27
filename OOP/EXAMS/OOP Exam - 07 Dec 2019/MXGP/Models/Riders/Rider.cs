namespace MXGP.Models.Riders
{
    using System.Collections.Generic;
    using System;
    using MXGP.Utilities.Messages;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    public class Rider : IRider
    {
        private string name;
        private IMotorcycle motorcycle;
        private bool canPractise;
        private int numberOfWins;

        public Rider(string name)
        {
            this.Name = name;

        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    var exMsg = String.Format(ExceptionMessages.InvalidName, value, 5);
                    throw new ArgumentException(exMsg);
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle
        {
            get => this.motorcycle;
            private set
            {
                this.motorcycle = value;
            }
        }

        public int NumberOfWins
        {
            get => this.numberOfWins;
            private set
            {
                this.numberOfWins = value;
            }
        }

        public bool CanParticipate
        {
            get
            {
                if (this.motorcycle != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(ExceptionMessages.MotorcycleInvalid);

            }

            this.Motorcycle = motorcycle;
        }
    }
}
