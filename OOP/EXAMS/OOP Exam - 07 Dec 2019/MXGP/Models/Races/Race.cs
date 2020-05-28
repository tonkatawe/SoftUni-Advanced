namespace MXGP.Models.Races
{
    using System.Linq;
    using System;
    using MXGP.Utilities.Messages;
    using System.Collections.Generic;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string race, int laps)
        {
            this.Name = race;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    var exMsg = String.Format(ExceptionMessages.InvalidName, value,5);
                    throw new ArgumentException(exMsg);
                }

                this.name = value;
            }
        }
        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    var exMsg = String.Format(ExceptionMessages.InvalidNumberOfLaps, value, 1);
                    throw new ArgumentException(exMsg);
                }

                this.laps = value;
            }
        }
        public IReadOnlyCollection<IRider> Riders => this.riders;

        public void AddRider(IRider rider)
        {
            var currentRider = this.riders.FirstOrDefault(x => x == rider);
            if (rider == null)
            {
                throw new ArgumentNullException(ExceptionMessages.RiderInvalid);
            }

            if (rider.Motorcycle == null)
            {
                var exMsg = String.Format(ExceptionMessages.RiderNotParticipate, rider.Name);
                throw new ArgumentException(exMsg);
            }

            if (this.riders.Contains(rider))
            {
                var exMsg = string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name);
                throw new ArgumentNullException(exMsg);
            }

            this.riders.Add(rider);
        }
    }
}
