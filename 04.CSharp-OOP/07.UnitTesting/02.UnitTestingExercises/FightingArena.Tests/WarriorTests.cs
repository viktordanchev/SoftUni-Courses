using NUnit.Framework;
using System.Reflection;
using System;

namespace FightingArena.Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private Warrior warrior;
        private Warrior enemyWarrior;
        private string name;
        private int damage;
        private int hp;

        [SetUp]
        public void Setup()
        {
            name = "Brotalniq";
            damage = 350;
            hp = 1200;
            warrior = new(name, damage, hp);
            enemyWarrior = new("Siuleimanfire", 470, 1450);
        }

        [Test]
        public void Constructor_MakeNewWarrior()
        {
           Assert.AreEqual(name, warrior.Name);
           Assert.AreEqual(damage, warrior.Damage);
           Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        public void IfNameIsNullOrEmptyShouldThrowsException()
        {
            name = string.Empty;

            Assert.Throws<ArgumentException>(() => warrior = new(name, damage, hp));
            Assert.Throws<ArgumentException>(() => warrior = new(null, damage, hp));
        }

        [Test]
        public void IfDamageIsEqualOrBelowZeroShouldThrowsException()
        {
            damage = -100;

            Assert.Throws<ArgumentException>(() => warrior = new(name, damage, hp));
            Assert.Throws<ArgumentException>(() => warrior = new(name, 0, hp));
        }

        [Test]
        public void IfHPIsBelowZeroShouldThrowsException()
        {
            hp = -100;

            Assert.Throws<ArgumentException>(() => warrior = new(name, damage, hp));
        }

        [Test]
        public void AttackMethod_TryAttackWithHPLessThanMIN_ATTACK_HPShouldThrowsException()
        {
            hp = 20;
            warrior = new(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }

        [Test]
        public void AttackMethod_TryAttackEnemyWithHPLessThanMIN_ATTACK_HPShouldThrowsException()
        {
            name = "Siuleimanfire";
            damage = 470;
            hp = 3;
            enemyWarrior = new(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }

        [Test]
        public void AttackMethod_TryAttackEnemyWithMoreDamageThanThisHPShouldThrowsException()
        {
            hp = 150;
            warrior = new(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }

        [Test]
        public void AttackMethod_AttackEnemyWarrior()
        {
            warrior.Attack(enemyWarrior);

            Assert.AreEqual(730, warrior.HP);
        }

        [Test]
        public void AttackMethod_DamageIsBiggerThanEnemyHp()
        {
            damage = 2000;
            warrior = new(name, damage, hp);

            warrior.Attack(enemyWarrior);

            Assert.AreEqual(0, enemyWarrior.HP);
        }

        [Test]
        public void AttackMethod_DamageIsSmallerThanEnemyHp()
        {
            warrior.Attack(enemyWarrior);

            Assert.AreEqual(1100, enemyWarrior.HP);
            Assert.AreEqual(730, warrior.HP);
        }
    }
}