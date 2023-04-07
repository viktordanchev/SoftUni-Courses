using NUnit.Framework;

namespace HeroRepository.Tests
{
    public class HeroTests
    {
        private Hero hero;
        private string name;
        private int level;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_MakeNewHeroProperly()
        {
            name = "Zulaman";
            level = 100;
            hero = new Hero(name, level);

            Assert.AreEqual(name, hero.Name);
            Assert.AreEqual(level, hero.Level);
        }
    }
}