
namespace HAD.Entities.Heroes
{

    using HAD.Contracts;
    public class Wizard : BaseHero, IHero
    {
        private const long BaseStrengthHeroStrength = 25;
        private const long BaseStrengthHeroAgility = 25;
        private const long BaseStrengthHeroIntelligence = 100;
        private const long BaseStrengthHeroHitPoints = 100;
        private const long BaseStrengthHeroDamage = 250;
        public Wizard(string name)
            : base(name, BaseStrengthHeroStrength, BaseStrengthHeroAgility, BaseStrengthHeroIntelligence, BaseStrengthHeroHitPoints, BaseStrengthHeroDamage)
        {
        }
    }
}
