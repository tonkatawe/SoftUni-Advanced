﻿using System;
using System.Linq;
using System.Reflection;
using HAD.Contracts;
using HAD.Core.Factory.Contracts;
using HAD.Entities.Heroes;

namespace HAD.Core.Factory
{
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string heroType, string name)
        {
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == heroType);
            var hero = (IHero)Activator.CreateInstance(type, name);

            return hero;
        }
    }
}
