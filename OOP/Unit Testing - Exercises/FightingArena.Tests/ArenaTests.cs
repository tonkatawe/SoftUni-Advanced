using System;
//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Stamat", 10, 50);
        }

        [Test]
        public void TestIfConstructorWorkCorrectly()
        {
            //Arrange
            var arena = new Arena();
            //Assert
            Assert.That(arena.Count, Has.No.Null);
        }
        [Test]
        public void TestIfArenaCountWorksCorrectly()
        {
            //Arrange
            var arena = new Arena();
            var otherWarrior = new Warrior("Minko", 10, 50);
            var exceptedCount = 2;
            //Act
            arena.Enroll(this.warrior);
            arena.Enroll(otherWarrior);
            var actualCount = arena.Count;
            //Assert
            Assert.AreEqual(exceptedCount, actualCount);
        }

        [Test]
        public void EachEnrolledWarriorShouldBeDifferent()
        {
            //Arrange
            var arena = new Arena();
            var otherWarrior = this.warrior;
            arena.Enroll(this.warrior);
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(otherWarrior);
            }).Message.Equals("Warrior is already enrolled for the fights!");
        }

        [Test]
        public void TestFightingWithMissingAttacker()
        {
            //Assert
            var otherWarrior = new Warrior("Minko", 50, 100);
            var arena = new Arena();
            arena.Enroll(this.warrior);


            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //ACT
                arena.Fight(this.warrior.Name, otherWarrior.Name);
            });

        }
        [Test]
        public void TestBetWeenTwoWarriors()
        {
            //Assert
            var otherWarrior = new Warrior("Minko", 50, 100);
            var arena = new Arena();
            arena.Enroll(this.warrior);
            arena.Enroll(otherWarrior);
            var expectedAtackerHP = this.warrior.HP - otherWarrior.Damage;
            var expectedDefenderHP = otherWarrior.HP - this.warrior.Damage;

            //ACT
            arena.Fight(this.warrior.Name, otherWarrior.Name);
            var actualAtackerHP = this.warrior.HP;
            var actualDefenderHP = otherWarrior.HP;

            //Assert
            Assert.AreEqual(expectedAtackerHP, actualAtackerHP);
            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);

        }
    }
}
