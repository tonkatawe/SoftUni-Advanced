
namespace MXGP.Core
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Repositories.Contracts;
    using MXGP.Utilities.Messages;
    using Enumerable = System.Linq.Enumerable;
    using MXGP.Core.Contracts;
    public class ChampionshipController : IChampionshipController
    {

        private MotorcycleRepository motorcycles;
        private RaceRepository races;
        private RiderRepository riders;

        public ChampionshipController()

        {
            this.motorcycles = new MotorcycleRepository();
            this.races = new RaceRepository();
            this.riders = new RiderRepository();

        }
        public string CreateRider(string riderName)
        {
            var rider = this.riders.GetByName(riderName);
            if (this.riders.GetAll().Contains(rider))
            {
                var exMsg = String.Format(ExceptionMessages.RaceExists, riderName);
                throw new ArgumentNullException(exMsg);
            }
            else
            {
                rider = new Rider(riderName);
            }
            this.riders.Add(rider);
            var result = String.Format(OutputMessages.RiderCreated, riderName);
            return result;
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = this.motorcycles.GetByName(model);

            if (this.motorcycles.GetAll().Contains(motorcycle))
            {
                var exMsg = String.Format(ExceptionMessages.MotorcycleExists, model);
                throw new ArgumentException(exMsg);
            }
            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            this.motorcycles.Add(motorcycle);
            var result = String.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
            return result;
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.races.GetByName(name);
            if (this.races.GetAll().Contains(race))
            {
                var exMsg = String.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(exMsg);
            }
            else
            {
                race = new Race(name, laps);
            }

            this.races.Add(race);
            var result = String.Format(OutputMessages.RaceCreated, name);
            return result;
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.races.GetByName(raceName);
            var rider = this.riders.GetByName(riderName);
            if (!this.riders.GetAll().Contains(rider))
            {
                var exMsg = String.Format(ExceptionMessages.RiderNotFound, riderName);
                throw new InvalidOperationException(exMsg);
            }

            if (!this.races.GetAll().Contains(race))
            {
                var exMsg = String.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(exMsg);
            }

            race.AddRider(rider);
            var result = String.Format(OutputMessages.RiderAdded, riderName, raceName);
            return result;
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var motorcycle = this.motorcycles.GetByName(motorcycleModel);
            var rider = this.riders.GetByName(riderName);
            if (!this.riders.GetAll().Contains(rider))
            {
                var exMsg = String.Format(ExceptionMessages.RiderNotFound, riderName);
                throw new InvalidOperationException(exMsg);
            }

            if (!this.motorcycles.GetAll().Contains(motorcycle))
            {
                var exMsg = String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel);
                throw new InvalidOperationException(exMsg);
            }
            rider.AddMotorcycle(motorcycle);
            var result = String.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
            return result;
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);
            if (!this.races.GetAll().Contains(race))
            {
                var exMsg = String.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(exMsg);
            }

            var raceCount = race.Riders.Count;
            if (race.Riders.Count < 3)
            {
                var exMsg = String.Format(ExceptionMessages.RaceInvalid, raceName, 3);
                throw new InvalidOperationException(exMsg);
            }
            var result = new StringBuilder();

            var i = 0;
            foreach (var rider in riders.GetAll().OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)))
            {
                i++;
                if (i == 1)
                {
                    result.AppendLine(String.Format(OutputMessages.RiderFirstPosition, rider.Name, raceName));
                }
                if (i == 2)
                {
                    result.AppendLine(String.Format(OutputMessages.RiderSecondPosition, rider.Name, raceName));
                }
                if (i == 3)
                {
                    result.AppendLine(String.Format(OutputMessages.RiderThirdPosition, rider.Name, raceName));
                    break;
                }
            }

            this.races.Remove(race);
            return result.ToString().TrimEnd();
        }
    }
}
