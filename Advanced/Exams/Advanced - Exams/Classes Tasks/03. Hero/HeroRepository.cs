using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;
        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name) //here might be occur some error ;)
        {
            this.data.RemoveAll(x => x.Name == name);
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();

        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();

        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var hero in this.data)
            {
                result.AppendLine(hero.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
