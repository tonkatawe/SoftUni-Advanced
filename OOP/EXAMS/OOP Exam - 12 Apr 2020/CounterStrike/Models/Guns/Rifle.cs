namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int RifleStrikeAtTime = 10;
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount >= RifleStrikeAtTime)
            {
                this.BulletsCount -= RifleStrikeAtTime;
                return RifleStrikeAtTime;
            }
            return 0;
        }
    }
}
