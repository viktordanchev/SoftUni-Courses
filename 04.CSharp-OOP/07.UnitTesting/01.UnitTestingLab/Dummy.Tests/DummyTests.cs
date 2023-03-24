using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        private Dummy dummy;
        private int health;
        private int experience;

        [SetUp]
        public void Setup()
        {
            health = 10;
            experience = 10;
            dummy = new(health, experience);
        }

        [Test]
        public void DummyLosesHealthWhenIsAttacked()
        {
            dummy.TakeAttack(1);

            Assert.AreEqual(health - 1, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsAnExceptionWhenIsAttacked()
        {
            dummy.TakeAttack(health);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        }
        
        [Test]
        public void DeadDummyShouldGiveXP()
        {
            dummy = new(health - 10, experience);

            Assert.AreEqual(experience, dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}