using NUnit.Framework;
using System;

namespace DummyTests
{
    public class DummyTests
    {
        Axe axe;
        Dummy dummy;

        [SetUp]
        public void Setup()
        {
            axe = new(10, 10);
            dummy = new(10, 10);
        }

        [Test]
        public void DummyLosesHealthWhenIsAttacked()
        {
            axe.Attack(dummy);

            Assert.That(0, Is.EqualTo(dummy.Health));
        }
        
        [Test]
        public void DeadDummyThrowsAnExceptionWhenIsAttacked()
        {
            dummy = new(0, 10);
            
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
        
        [Test]
        public void DeadDummyCanGiveXP()
        {
            dummy = new(0, 10);

            Assert.That(10, Is.EqualTo(dummy.GiveExperience()));
        }
        
        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}