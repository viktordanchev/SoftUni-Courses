using NUnit.Framework;
using PlanetWars;
using System;

namespace PlanetWarsUnitTests.Tests
{
    public class WeaponTests
    {
        Weapon weapon;
        private string name;
        private double price;
        private int destructionLevel;

        [SetUp]
        public void Setup()
        {
            name = "Grenade";
            price = 5;
            destructionLevel = 2;
            weapon = new Weapon(name, price, destructionLevel);
        }

        [Test]
        public void Constructor_MakeNewWeaponCorrectly()
        {
            name = "Bomb";
            price = 100;
            destructionLevel = 6;

            weapon = new Weapon(name, price, destructionLevel);

            Assert.AreEqual(name, weapon.Name);
            Assert.AreEqual(price, weapon.Price);
            Assert.AreEqual(destructionLevel, weapon.DestructionLevel);
        }
        
        [Test]
        public void PriceProperty_Below0ShouldThrowException()
        {
            price = -20;

            Assert.Throws<ArgumentException>(() => weapon = new Weapon(name, price, destructionLevel));
        }
        
        [Test]
        public void IncreaseDestructionLevelMethod_IncreaseWith1()
        {
            weapon.IncreaseDestructionLevel();

            Assert.AreEqual(destructionLevel + 1, weapon.DestructionLevel);
        }
        
        [Test]
        public void IsNuclearProperty_ReturnTrue()
        {
            destructionLevel = 15;

            weapon = new Weapon(name, price, destructionLevel);

            Assert.AreEqual(true, weapon.IsNuclear);
        }

        [Test]
        public void IsNuclearProperty_ReturnFalse()
        {
            destructionLevel = 5;

            weapon = new Weapon(name, price, destructionLevel);

            Assert.AreEqual(false, weapon.IsNuclear);
        }
    }
}