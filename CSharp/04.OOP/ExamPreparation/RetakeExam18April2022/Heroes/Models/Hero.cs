using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;

namespace Heroes.Models
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);

                name = value;
            }
        }

        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);

                health = value;
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);

                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                    throw new ArgumentException(ExceptionMessages.WeaponNull);

                weapon = value;
            }
        }

        public bool IsAlive
        {
            get 
            {
                if (Health > 0)
                    return true;

                return false; 
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (Armour - points > 0)
            {
                Armour -= points;
                return;
            }

            points -= Armour;
            Armour = 0;

            if (Health - points > 0)
            {
                Health -= points;
                return;
            }

            Health = 0;
        }
    }
}
