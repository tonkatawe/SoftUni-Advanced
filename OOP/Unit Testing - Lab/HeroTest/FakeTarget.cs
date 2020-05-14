
using Skeleton;

namespace HeroTest
{
    public class FakeTarget : ITarget
    {
        private const int fakeTargetHealth = 20;
        private const int fakeTargetExperience = 50;
        public FakeTarget()
        {
            this.Health = fakeTargetHealth;
        }

        public int Health { get; private set; }

        public int GiveExperience()
        {
            return fakeTargetExperience;
        }

        public bool IsDead()
        {
            return this.Health <= 0;
        }

        public void TakeAttack(int attackPoints)
        {
            this.Health -= attackPoints;
        }
    }
}
