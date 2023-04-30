using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        HeroRepository heroes;
        WeaponRepository weapons;
        List<string> validHeroTypes = new List<string>() { "Knight", "Barbarian" };
        List<string> validWeaponTypes = new List<string>() { "Mace", "Claymore" };

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.FindByName(heroName) == null)
                return string.Format(OutputMessages.HeroDoesNotExist, heroName);

            if (weapons.FindByName(weaponName) == null)
                return string.Format(OutputMessages.WeaponDoesNotExist, weaponName);

            IHero hero = heroes.FindByName(heroName);

            if (hero.Weapon != null)
                return string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName);

            IWeapon weapon = weapons.FindByName(weaponName);

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return string.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
                return string.Format(OutputMessages.HeroAlreadyExist, name);

            if (!validHeroTypes.Any(t => t == type))
                return string.Format(OutputMessages.HeroTypeIsInvalid);

            IHero hero = null;
            string output = string.Empty;

            switch (type)
            {
                case "Knight":
                    hero = new Knight(name, health, armour);
                    output = string.Format(OutputMessages.SuccessfullyAddedKnight, name);
                    break;
                case "Barbarian":
                    hero = new Barbarian(name, health, armour);
                    output = string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
                    break;
            }

            heroes.Add(hero);
            return output;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
                return string.Format(OutputMessages.WeaponAlreadyExists, name);

            if (!validWeaponTypes.Any(w => w == type))
                return string.Format(OutputMessages.WeaponTypeIsInvalid);

            IWeapon weapon = null;

            switch (type)
            {
                case "Claymore":
                    weapon = new Claymore(name, durability);
                    break;
                case "Mace":
                    weapon = new Mace(name, durability);
                    break;
            }

            weapons.Add(weapon);
            return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
        }

        public string HeroReport()
        {
            List<IHero> orderedHeroes = heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var hero in orderedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: { hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");

                if (hero.Weapon == null)
                {
                    sb.AppendLine("--Weapon: Unarmed");
                    continue;
                }

                sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
            }

            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            Map map = new Map();
            List<IHero> allHeroes = heroes.Models.Where(h => h.Weapon != null).Where(h => h.IsAlive).ToList();
            return map.Fight(allHeroes);
        }
    }
}
