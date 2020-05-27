
namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double DecreaseOxygenByBreath = 5;
        private const double InitialOxygen = 70;
        public Biologist(string name)
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= DecreaseOxygenByBreath;
            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }

        }
    }
}
