namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialShotBulletsPerFire = 1;
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        public Pistol(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            //todo I`m not sure for this method
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
