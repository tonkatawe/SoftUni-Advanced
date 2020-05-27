
namespace SantaWorkshop.Models.Instruments
{
    using SantaWorkshop.Models.Instruments.Contracts;
    public class Instrument : IInstrument
    {
        private int power;
        private const int DecreaseInstrumentPowerByUsing = 10;

        public Instrument(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.power = value;
            }
        }

        public void Use() => this.Power -= DecreaseInstrumentPowerByUsing;
        public bool IsBroken() => this.Power == 0;
    }
}
