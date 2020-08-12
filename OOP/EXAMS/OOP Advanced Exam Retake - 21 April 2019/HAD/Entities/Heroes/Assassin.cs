


namespace HAD.Entities.Heroes
{
    using HAD.Contracts;
    public class Assassin : BaseHero, IHero
    {
        private const long BaseStrengthHeroStrength = 25;
        private const long BaseStrengthHeroAgility = 100;
        private const long BaseStrengthHeroIntelligence = 15;
        private const long BaseStrengthHeroHitPoints = 150;
        private const long BaseStrengthHeroDamage = 300;
        public Assassin(string name)
            : base(name, BaseStrengthHeroStrength, BaseStrengthHeroAgility, BaseStrengthHeroIntelligence, BaseStrengthHeroHitPoints, BaseStrengthHeroDamage)
        {
        }
    }
}
