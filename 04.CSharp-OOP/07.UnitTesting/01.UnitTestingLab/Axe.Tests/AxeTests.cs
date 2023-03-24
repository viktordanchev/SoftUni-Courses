using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 10;
            axe = new(attackPoints, durabilityPoints);
            dummy = new(10, 10);
        }

        [Test]
        public void WeaponLosesDurabilityAfterEachAttack()
        {
            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void AttackingWithABrokenWeapon()
        {
            axe = new(attackPoints, durabilityPoints - 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}