using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = new List<IHero>();
            List<IHero> barbarians = new List<IHero>();
            int knightCorpses = 0;
            int barbarianCorpses = 0;

            knights = players.Where(p => p.GetType().Name == "Knight").ToList();
            barbarians = players.Where(p => p.GetType().Name == "Barbarian").ToList();

            while (knights.Count > knightCorpses && barbarians.Count > barbarianCorpses)
            {
                barbarianCorpses += KnightsAttack(knights, barbarians);

                knightCorpses += BarbariansAttack(barbarians, knights);
            }

            if (knights.Count > 0)
                return string.Format(OutputMessages.MapFightKnightsWin, knightCorpses);

            return string.Format(OutputMessages.MapFigthBarbariansWin, barbarianCorpses);
        }

        static int KnightsAttack(List<IHero> knights, List<IHero> barbarians)
        {
            int barbarianCorpses = 0;
            int index = 0;

            foreach (var knight in knights)
            {
                if (index == barbarians.Count)
                    break;

                if (knight.IsAlive)
                {
                    barbarians[index].TakeDamage(knight.Weapon.DoDamage());

                    if (!barbarians[index].IsAlive)
                    {
                        barbarians.RemoveAt(index--);
                        barbarianCorpses++;
                    }

                    index++;
                }
            }

            return barbarianCorpses;
        }

        static int BarbariansAttack(List<IHero> barbarians, List<IHero> knights)
        {
            int knightCorpses = 0;
            int index = 0;

            foreach (var barbarian in barbarians)
            {
                if (index == knights.Count)
                    break;

                if (barbarian.IsAlive)
                {
                    knights[index].TakeDamage(barbarian.Weapon.DoDamage());

                    if (!knights[index].IsAlive)
                    {
                        knights.RemoveAt(index--);
                        knightCorpses++;
                    }

                    index++;
                }
            }

            return knightCorpses;
        }
    }
}
