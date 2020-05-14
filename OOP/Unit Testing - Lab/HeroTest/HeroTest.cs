using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using HeroTest;
using Skeleton;

public class HeroTests
{
    [Test]
    public void HeroShouldGainExperienceWhenTargetDies()
    {
        //Arrange
        Hero hero = new Hero("Grigor", new FakeAxe());
        ITarget fakeTarget = new FakeTarget();
        //Act
        hero.Attack(fakeTarget);
        
        //Assert
        Assert.That(hero.Experience, Is.EqualTo(0));
        hero.Attack(fakeTarget);
        Assert.That(hero.Experience, Is.EqualTo(50));
    }

    [Test]
    public void HeroShouldGainExperienceWhenTargetDiesMocking()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(p => p.Health).Returns(0);
        fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
        fakeTarget.Setup(p => p.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(20));

    }
}

