﻿
namespace HAD.Entities.Heroes
{
    using HAD.Contracts;
    public class Barbarian : BaseHero, IHero
    {
        private const long BaseStrengthHeroStrength = 90;
        private const long BaseStrengthHeroAgility = 25;
        private const long BaseStrengthHeroIntelligence = 10;
        private const long BaseStrengthHeroHitPoints = 350;
        private const long BaseStrengthHeroDamage = 150;

        public Barbarian(string name)
            : base(name, BaseStrengthHeroStrength, BaseStrengthHeroAgility, BaseStrengthHeroIntelligence, BaseStrengthHeroHitPoints, BaseStrengthHeroDamage)
        { }
    }
}