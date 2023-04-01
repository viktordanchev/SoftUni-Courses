using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string WeaponTypeNull = "Weapon type cannot be null or empty.";

        public const string DurabilityBelowZero = "Durability cannot be below 0.";

        public const string HeroNameNull = "Hero name cannot be null or empty.";

        public const string HeroHealthBelowZero = "Hero health cannot be below 0.";

        public const string HeroArmourBelowZero = "Hero armour cannot be below 0.";

        public const string WeaponNull = "Weapon cannot be null.";
    }
}
