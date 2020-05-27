
namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Utilities.Messages;
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;
        private IRepository<IAstronaut> astronauts;
        private IMission mission;
        private int exploredPlanet;
        public Controller()
        {
            this.planets = new PlanetRepository();
            this.astronauts = new AstronautRepository();
            this.mission = new Mission();

        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(astronaut);
            var result = String.Format(OutputMessages.AstronautAdded, type, astronautName);
            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            var result = String.Format(OutputMessages.PlanetAdded, planetName);
            return result;
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.FindByName(astronautName);
            if (astronaut == null)
            {
                var exMsg = String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName);
                throw new InvalidOperationException(exMsg);
            }

            this.astronauts.Remove(astronaut);
            var result = String.Format(OutputMessages.AstronautRetired, astronautName);
            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            var suitableAstronauts = this.astronauts.Models.ToList<IAstronaut>().FindAll(x => x.Oxygen >= 60);


            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            this.mission.Explore(planet, suitableAstronauts);


            exploredPlanet++;
            var deadAstronauts = suitableAstronauts.FindAll(x => x.Oxygen == 0);

            var result = String.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count); //todo I`m not sure :)
            return result;
        }
        public string Report()
        {
            var result = new StringBuilder();
            result.AppendLine($"{this.exploredPlanet} planets were explored");
            result.AppendLine($"Astronauts info:");
            foreach (var astronaut in this.astronauts.Models)
            {
                result.AppendLine($"Name: {astronaut.Name}");
                result.AppendLine($"Oxygen: {astronaut.Oxygen}");
                result.AppendLine($"Bag items: {(!astronaut.Bag.Items.Any() ? "none" : string.Join(", ", astronaut.Bag.Items))}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
