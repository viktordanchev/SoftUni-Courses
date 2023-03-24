using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    public class AxeTests
    {
        Axe axe;
        Dummy dummy;
        int attackPoints;
        int durabilityPoints;

        [SetUp]
        public void Startup()
        {
            attackPoints = 10;
            durabilityPoints = 10;
            dummy = new(attackPoints, durabilityPoints);
        }

        [Test]
        public void TryAttackingWithABrokenWeapon()
        {
            axe = new(10, 0);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe = new(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }
    }
}