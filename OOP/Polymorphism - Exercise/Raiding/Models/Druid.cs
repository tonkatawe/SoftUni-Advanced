﻿

namespace Raiding.Models
{
  public  class Druid:BaseHero
    {
        public Druid(string name, int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility()+$"healed for {this.Power}";
        }
    }
}
