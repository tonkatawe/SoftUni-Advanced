using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void HeroConstructorWorkCorrectly()
    {
        //Arrange
        var test = new HeroRepository();
        //Assert & Act
        Assert.That(test, Has.No.Null);

    }
    [Test]
    public void ShouldNotCreateHeroLikeNull()
    {
        //Arrange

        Hero testHero = null;
        var test = new HeroRepository();
        //Assert & Act
        Assert.Throws<ArgumentNullException>(() =>
        {
            test.Create(testHero);
        });
    }
    [Test]
    public void ShouldNotCreateExistHero()
    {
        //Arrange

        var name = "pesho";
        var level = 10;

        Hero testHero = new Hero(name, level);
        var test = new HeroRepository();
        //Assert & Act
        Assert.Throws<InvalidOperationException>(() =>
        {
            test.Create(testHero);
            test.Create(testHero);
        });
    }
    [Test]
    public void ShouldNotRemoveNullHero()
    {
        //Arrange
        
        var test = new HeroRepository();
        //Assert & Act
        Assert.Throws<ArgumentNullException>(() =>
        {
            test.Remove("");
        });

    }
    [Test]
    public void RemoveHeroShouldTrue()
    {
        //Arrange

        var name = "pesho";
        var level = 10;

        Hero testHero = new Hero(name, level);
        var test = new HeroRepository();
        test.Create(testHero);
        //Assert & Act
      Assert.IsTrue(test.Remove(name));

    }
    [Test]
    public void ShoulGetHeroCorrectlyByName()
    {
        //Arrange
        var name = "pesho";
        var level = 10;
        Hero testHero = new Hero(name, level);
        var test = new HeroRepository();
        test.Create(testHero);
        //Act
        var actualHero = test.GetHero("pesho").Name;
        //Assert
        Assert.AreEqual(name,actualHero);

    }
    [Test]
    public void ShouldGetHeroWithHighestLevel()
    {
        //Arrange
        var nameOne = "pesho";
        var levelOne = 10;
        var nameTwo = "gosho";
        var levelTwo = 20;
        Hero testHeroOne = new Hero(nameOne, levelOne);
        Hero testHeroTwo = new Hero(nameTwo, levelTwo);
        var test = new HeroRepository();
        test.Create(testHeroOne);
        test.Create(testHeroTwo);
        //Act
        var actualHero = test.GetHeroWithHighestLevel();
        //Assert
        Assert.AreEqual(testHeroTwo, actualHero);
        }
    [Test]
    public void ShouldReturnCollection()
    {
        //Arrange
        var nameOne = "pesho";
        var levelOne = 10;
        var nameTwo = "gosho";
        var levelTwo = 20;
        Hero testHeroOne = new Hero(nameOne, levelOne);
        Hero testHeroTwo = new Hero(nameTwo, levelTwo);
        var test = new HeroRepository();
        test.Create(testHeroOne);
        test.Create(testHeroTwo);
        var expectedCount = 2;
        //Act
        var actualCount = test.Heroes.Count;
        //Assert
        Assert.AreEqual(expectedCount, actualCount);

    }
}