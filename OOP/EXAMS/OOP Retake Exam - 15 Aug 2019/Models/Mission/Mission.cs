namespace SpaceStation.Models.Mission
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            //todo I am not sure for this method 
            foreach (var astronaut in astronauts)
            {
                while (astronaut.Oxygen > 0 && planet.Items.Any())
                {
                    var currentItems = planet.Items.First();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(currentItems);
                    planet.Items.Remove(currentItems);
                }

                if (astronaut.Oxygen < 0)
                {
                    astronaut.Bag.Items.Clear();
                }
            }
        }
    }
}
