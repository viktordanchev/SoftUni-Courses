using Raiding.Heroes;
using Raiding.Heroes.DamageDealers;
using Raiding.Heroes.Healers;
using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new();

            int numOfPlayers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numOfPlayers; i++)
            {
                string playerName = Console.ReadLine();
                string playerHero = Console.ReadLine();

                BaseHero hero;
                switch (playerHero)
                {
                    case "Druid":
                        hero = new Druid(playerName);
                        break;
                    case "Paladin":
                        hero = new Paladin(playerName);
                        break;
                    case "Rogue":
                        hero = new Rogue(playerName);
                        break;
                    case "Warrior":
                        hero = new Warrior(playerName);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        i--;
                        continue;
                }

                raidGroup.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidGroupPower = 0;

            foreach (BaseHero hero in raidGroup)
            {
                raidGroupPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (raidGroupPower >= bossPower)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
    }
}
