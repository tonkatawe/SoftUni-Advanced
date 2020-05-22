
namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int PistolStrikeAtTime = 1;
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount >= PistolStrikeAtTime)
            {
                this.BulletsCount -= PistolStrikeAtTime;
                return PistolStrikeAtTime;
            }
            return 0;
        }
    }
}
