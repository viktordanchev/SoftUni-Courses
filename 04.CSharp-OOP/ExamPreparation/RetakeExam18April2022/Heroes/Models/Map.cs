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

            while (knights.Count > 0 && barbarians.Count > 0)
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

            foreach (var knight in knights)
            {
                for (int i = 0; i < barbarians.Count; i++)
                {
                    barbarians[i].TakeDamage(knight.Weapon.DoDamage());

                    if (!barbarians[i].IsAlive)
                    {
                        barbarianCorpses++;
                        barbarians.RemoveAt(i--);
                    }
                }
            }

            return barbarianCorpses;
        }

        static int BarbariansAttack(List<IHero> barbarians, List<IHero> knights)
        {
            int knightCorpses = 0;

            foreach (var barbarian in barbarians)
            {
                for (int i = 0; i < knights.Count; i++)
                {
                    knights[i].TakeDamage(barbarian.Weapon.DoDamage());

                    if (!knights[i].IsAlive)
                    {
                        knightCorpses++;
                        knights.RemoveAt(i--);
                    }
                }
            }

            return knightCorpses;
        }
    }
}
