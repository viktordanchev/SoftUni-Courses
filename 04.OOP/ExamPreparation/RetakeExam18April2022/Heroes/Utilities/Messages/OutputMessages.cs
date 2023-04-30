using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities.Messages
{
    public static class OutputMessages
    {
        public const string MapFightKnightsWin = "The knights took {0} casualties but won the battle.";

        public const string MapFigthBarbariansWin = "The barbarians took {0} casualties but won the battle.";

        public const string HeroAlreadyExist = "The hero {0} already exists.";

        public const string HeroTypeIsInvalid = "Invalid hero type.";

        public const string SuccessfullyAddedKnight = "Successfully added Sir {0} to the collection.";

        public const string SuccessfullyAddedBarbarian = "Successfully added Barbarian {0} to the collection.";

        public const string WeaponAlreadyExists = "The weapon {0} already exists.";

        public const string WeaponTypeIsInvalid = "Invalid weapon type.";

        public const string WeaponAddedSuccessfully = "A {0} {1} is added to the collection.";

        public const string HeroDoesNotExist = "Hero {0} does not exist.";

        public const string WeaponDoesNotExist = "Weapon {0} does not exist.";

        public const string HeroAlreadyHasWeapon = "Hero {0} is well-armed.";

        public const string WeaponAddedToHero = "Hero {0} can participate in battle using a {1}.";
    }
}
