using NUnit.Framework;
using System;

public class HeroRepositoryTests
{
    private HeroRepository heroes;
    private Hero hero;
    private string name;
    private int level;

    [SetUp]
    public void Setup()
    {
        name = "Bogdan";
        level = 230;
        hero = new Hero(name, level);
        heroes = new HeroRepository();
    }

    [Test]
    public void HeroConstructor_MakeNewHeroProperly()
    {
        name = "Zulaman";
        level = 100;
        hero = new Hero(name, level);

        Assert.AreEqual(name, hero.Name);
        Assert.AreEqual(level, hero.Level);
    }

    [Test]
    public void HeroRepositoryConstructor_MakeNewHeroRepositoryProperly()
    {
        heroes = new HeroRepository();

        Assert.AreEqual(0, heroes.Heroes.Count);
    }

    [Test]
    public void CreateMethod_ReturnMessageSuccessfullyAddedHero()
    {
        string text = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.AreEqual(text, heroes.Create(hero));
    }

    [Test]
    public void CreateMethod_IfTryToCreateExistingHeroShouldThrowException()
    {
        heroes.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroes.Create(hero));
    }

    [Test]
    public void CreateMethod_IfTryToCreateNullHeroShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => heroes.Create(null));
    }

    [Test]
    public void RemoveMethod_IfNameIsNullOrWhiteSpaceShouldThrowException()
    {
        heroes.Create(hero);

        Assert.Throws<ArgumentNullException>(() => heroes.Remove(null));
        Assert.Throws<ArgumentNullException>(() => heroes.Remove(" "));
    }

    [Test]
    public void RemoveMethod_ReturnTrueOrFalse()
    {
        heroes.Create(hero);

        Assert.AreEqual(true, heroes.Remove(name));
        Assert.AreEqual(false, heroes.Remove("Zulaman"));
    }

    [Test]
    public void GetHeroWithHighestLevelMethod_ReturnHighestLevelHero()
    {
        heroes.Create(this.hero);
        heroes.Create(new Hero("Zulaman", 100));

        Hero hero = heroes.GetHeroWithHighestLevel();

        Assert.AreEqual(name, hero.Name);
        Assert.AreEqual(level, hero.Level);
    }

    [Test]
    public void GetHeroMethod_ReturnHero()
    {
        heroes.Create(hero);

        Assert.AreEqual(hero, heroes.GetHero(name));
    }
}
