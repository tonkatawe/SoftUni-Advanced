﻿using System;
using Skeleton;

// Axe durability drop with 5 
public class Axe:IWeapon
{
    private int attackPoints;
    private int durabilityPoints;

    public Axe(int attack, int durability)
    {
        this.AttackPoints = attack;
        this.DurabilityPoints = durability;
    }

    public int AttackPoints
    {
        get { return this.attackPoints; }
        set { this.attackPoints = value; }
    }

    public int DurabilityPoints
    {
        get { return this.durabilityPoints; }
        set { this.durabilityPoints = value; }
    }

    public void Attack(ITarget target)
    {
        if (this.durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        this.durabilityPoints -= 1;
    }
}
