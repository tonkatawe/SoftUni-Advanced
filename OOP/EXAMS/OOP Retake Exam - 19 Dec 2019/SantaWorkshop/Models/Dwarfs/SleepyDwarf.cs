namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int SleepyDwarfEnergy = 50;
        private const int DecreaseEnergyByWork = 5;
        public SleepyDwarf(string name)
            : base(name, SleepyDwarfEnergy)
        {
        }

        public override void Work()
        {
            base.Work();
            this.Energy -= DecreaseEnergyByWork;
        }
    }
}
