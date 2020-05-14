﻿
namespace Skeleton
{
    public interface ITarget
    {
        int Health { get; }
        bool IsDead();
        int GiveExperience();
        void TakeAttack(int AttackPoints);
    }
}
