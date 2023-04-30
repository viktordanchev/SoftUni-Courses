using NUnit.Framework;
using PlanetWars;
using System;
using System.Linq;

namespace PlanetWarsUnitTests.Tests
{
    public class PlanetTests
    {
        Planet planet;
        Weapon weapon;
        Weapon secondWeapon;
        private string name;
        private double budget;
        private double amount;

        [SetUp] 
        public void Setup()
        {
            name = "Earth";
            budget = 20;
            planet = new Planet(name, budget);
            weapon = new Weapon("Bomb", 100, 5);
            secondWeapon = new Weapon("Granata", 100, 5);
            amount = 100;
        }

        [Test]
        public void Constructor_MakeNewPlanetCorrectly()
        {
            name = "Mars";
            budget = 40;
            planet = new Planet(name, budget);

            Assert.AreEqual(name, planet.Name);
            Assert.AreEqual(budget, planet.Budget);
        }

        [Test]
        public void NameProperty_IfIsNullOrEmptyShouldThrowException()
        {
            name = string.Empty;

            Assert.Throws<ArgumentException>(() => planet = new Planet(name, budget));
            Assert.Throws<ArgumentException>(() => planet = new Planet(null, budget));
        }
        
        [Test]
        public void BudgetProperty_IfIsSmallerThan0ShouldThrowException()
        {
            budget = -200;

            Assert.Throws<ArgumentException>(() => planet = new Planet(name, budget));
        }

        [Test]
        public void MilitaryPowerRatioProperty_SumAllWeaponsDestructionLevel()
        {
            planet.AddWeapon(secondWeapon);

            Assert.AreEqual(5, planet.MilitaryPowerRatio);
        }

        [Test]
        public void ProfitMethod_IncreaseBudget()
        {
            planet.Profit(amount);

            Assert.AreEqual(budget + 100, planet.Budget);
        }

        [Test]
        public void SpendFundsMethod_DecreaseBudget()
        {
            double amount = 10;

            planet.SpendFunds(amount);

            Assert.AreEqual(budget - 10, planet.Budget);
        }
        
        [Test]
        public void SpendFundsMethod_IfAmmountIsSmallerThan0ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(amount));
        }
        
        [Test]
        public void AddBombMethod_IncreaseWeaponsCount()
        {
            planet.AddWeapon(weapon);

            Assert.AreEqual(1, planet.Weapons.Count);
        }
        
        [Test]
        public void AddBombMethod_AddExistingWeaponShouldThrowException()
        {
            planet.AddWeapon(weapon);

            Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
        }
        
        [Test]
        public void RemoveWeapon_DecreaseWeaponsCount()
        {
            planet.AddWeapon(weapon);
            planet.RemoveWeapon("Bomb");

            Assert.AreEqual(0, planet.Weapons.Count);
        }
        
        [Test]
        public void UpgradeWeaponMethod_IncreaseWeaponDestructionLevel()
        {
            planet.AddWeapon(weapon);
            planet.UpgradeWeapon("Bomb");

            Assert.AreEqual(6, planet.Weapons.First(W => W.Name == "Bomb").DestructionLevel);
        }
        
        [Test]
        public void UpgradeWeaponMethod_IfNoSuchBombExistsShouldThrowException()
        {
            planet.AddWeapon(secondWeapon);

            Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Bomba"));
        }
        
        [Test]
        public void DestructOpponentMethod_ReturnWhoIsDestructed()
        {
            name = "Jupiter";
            budget = 10;

            planet.AddWeapon(secondWeapon);

            Assert.AreEqual("Jupiter is destructed!", planet.DestructOpponent(new Planet(name, budget)));
        }

        [Test]
        public void DestructOpponentMethod_IfOpponentMilitaryPowerRatioIsBiggerShouldThrowException()
        {
            Planet opponent = new Planet("Jupiter", 40);
            planet.AddWeapon(secondWeapon);
            opponent.AddWeapon(new Weapon("Granata", 100, 7));

            Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
        }
    }
}