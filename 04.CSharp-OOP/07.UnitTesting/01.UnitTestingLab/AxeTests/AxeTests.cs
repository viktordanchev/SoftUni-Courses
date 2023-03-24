using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    public class AxeTests
    {
        Axe axe;
        Dummy dummy;

        [SetUp]
        public void Startup()
        {
            axe = new(10, 10);
            dummy = new(10, 10);
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
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }
    }
}