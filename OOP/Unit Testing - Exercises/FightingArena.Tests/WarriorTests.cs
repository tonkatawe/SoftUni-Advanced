using System;
//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorkCorrectly()
        {
            //Arrange
            var expectedName = "Stamat";
            var expectedDemage = 10;
            var expectedHP = 50;
            //Act
            var warrior = new Warrior(expectedName, expectedDemage, expectedHP);
            var actualName = warrior.Name;
            var actualDemage = warrior.Damage;
            var actualHP = warrior.HP;
            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDemage, actualDemage);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void NameShouldNotNullEmptyOrWhiteSpace(string name)
        {
            //Arrange
            var demage = 10;
            var HP = 50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                var warrior = new Warrior(name, demage, HP);
            }).Message.Equals("Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void DamageShouldNotZeroOrNegative(int damage)
        {
            //Arrange
            var name = "Stamat";
            var HP = 50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                var warrior = new Warrior(name, damage, HP);
            }).Message.Equals("Damage value should be positive!");
        }

        [Test]
        public void HPShouldNotNegative()
        {
            //Arrange
            var name = "Stamat";
            var damage = 10;
            var HP = -50;
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                var warrior = new Warrior(name, damage, HP);
            }).Message.Equals("HP should not be negative!");

        }

        [Test]
        public void WarriorCannotAttackWhitMinHP()
        {
            //Arrange
            var name = "Stamat";
            var damage = 10;
            var HP = 20;
            var attackerWarrior = new Warrior(name, damage, HP);
            var difenderWarrior = new Warrior(name, damage, HP);
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                attackerWarrior.Attack(difenderWarrior);

            }).Message.Equals("Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void WarriorCannotAttackStrongerWarriors()
        {
            //Arrange
            var attackerName = "Stamat";
            var attackerDamage = 10;
            var attackerHP = 10;
            var defenderName = "Minko";
            var defenderDamage = 20;
            var defenderHP = 50;
            var attackerWarrior = new Warrior(attackerName,attackerDamage,attackerHP);
            var defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHP);
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                attackerWarrior.Attack(defenderWarrior);
            }).Message.Equals("You are trying to attack too strong enemy");

        }

        [Test]
        public void AfterAttackWarriorsHPShouldDecrease()
        {
            //Arrange
            var attackerName = "Stamat";
            var attackerDamage = 10;
            var attackerHP = 50;
            var defenderName = "Minko";
            var defenderDamage = 20;
            var defenderHP = 50;
            var attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);
            var defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHP);
            var expectedHP = 30;
            //Act
            attackerWarrior.Attack(defenderWarrior);
            var actualHp = attackerWarrior.HP;
            //Assert
            Assert.AreEqual(expectedHP, actualHp);

        }
        [Test]
        public void WarrierShoudKillOtherWarrierWithBiggerDamageThanHP()
        {
            //Arrange
            var attackerName = "Stamat";
            var attackerDamage = 70;
            var attackerHP = 50;
            var defenderName = "Minko";
            var defenderDamage = 20;
            var defenderHP = 50;
            var attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);
            var defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHP);
            var expectedHP = 0;
            //Act
            attackerWarrior.Attack(defenderWarrior);
            var actualHp = defenderWarrior.HP;
            //Assert
            Assert.AreEqual(expectedHP, actualHp);

        }
        [Test]
        public void WarrierShoudIncreaseOtherWarrierWithBiggerDamageThanHP()
        {
            //Arrange
            var attackerName = "Stamat";
            var attackerDamage = 70;
            var attackerHP = 50;
            var defenderName = "Minko";
            var defenderDamage = 20;
            var defenderHP = 80;
            var attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);
            var defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHP);
            var expectedHP =10;
            //Act
            attackerWarrior.Attack(defenderWarrior);
            var actualHp = defenderWarrior.HP;
            //Assert
            Assert.AreEqual(expectedHP, actualHp);

        }
    }
}