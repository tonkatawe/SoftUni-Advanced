using Skeleton;

namespace HeroTest
{
    public class FakeAxe : IWeapon
    {
        private const int fakeAxeAttackPoints = 10;

        public FakeAxe()
        {
            this.AttackPoints = fakeAxeAttackPoints;
        }

        public int AttackPoints { get; private set; }

        public void Attack(ITarget target)
        {
            target.TakeAttack(AttackPoints);
        }
    }
}
