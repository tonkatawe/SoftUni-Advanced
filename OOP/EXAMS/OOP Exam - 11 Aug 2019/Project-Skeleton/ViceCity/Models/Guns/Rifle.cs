namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialShotBulletsPerFire = 5;
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;

        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            this.BulletsPerBarrel -= InitialShotBulletsPerFire;
            if (this.BulletsPerBarrel == 0 && this.TotalBullets >= InitialBulletsPerBarrel)
            {
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }

            return InitialShotBulletsPerFire;
        }
    }
}
