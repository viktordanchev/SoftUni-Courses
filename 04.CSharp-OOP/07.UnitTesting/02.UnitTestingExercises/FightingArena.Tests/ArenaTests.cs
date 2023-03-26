using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior enemyWarrior;
        private string attacker;
        private string defender;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new("Brotalniq", 350, 1200);
            enemyWarrior = new("Siuleimanfire", 470, 1450);
            attacker = "Brotalniq";
            defender = "Siuleimanfire";
            arena.Enroll(warrior);
            arena.Enroll(enemyWarrior);
        }

        [Test]
        public void Constructor_MakeNewArenaWithTwoWarriors()
        {
            Assert.AreEqual(2, arena.Warriors.Count);
            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        public void EnrollMethod_EnrollWarriorWithExistingNameShouldThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new("Brotalniq", 750, 2200)));
        }

        [Test]
        public void EnrollMethod_EnrollNewWarrior()
        {
            warrior = new("Aragok", 67, 2400);
            arena.Enroll(warrior);

            Assert.AreEqual(3, arena.Warriors.Count);
            Assert.AreEqual(3, arena.Count);

        }

        [Test]
        public void FightMethod_AttackerNameIsNullShouldThrowsException()
        {
            attacker = "Aragok";

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));

        }

        [Test]
        public void FightMethod_DefenderNameIsNullShouldThrowsException()
        {
            defender = "Aragok";

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));
        }

        [Test]
        public void FightMethod_AttackerAttackDefender()
        {
            arena.Fight(attacker, defender);

            Assert.AreEqual(730, warrior.HP);
        }
    }
}