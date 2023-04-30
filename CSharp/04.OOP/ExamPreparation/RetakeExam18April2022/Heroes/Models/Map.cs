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
                barbarianCorpses += Attack(knights, barbarians);
                knightCorpses += Attack(barbarians, knights);
            }

            if (knights.Count > 0)
                return string.Format(OutputMessages.MapFightKnightsWin, knightCorpses);

            return string.Format(OutputMessages.MapFigthBarbariansWin, barbarianCorpses);
        }

        private int Attack(List<IHero> attackers, List<IHero> defenders)
        {
            int corpses = 0;

            foreach (var attacker in attackers)
            {
                for (int i = 0; i < defenders.Count; i++)
                {
                    defenders[i].TakeDamage(attacker.Weapon.DoDamage());

                    if (!defenders[i].IsAlive)
                    {
                        corpses++;
                        defenders.RemoveAt(i--);
                    }
                }
            }

            return corpses;
        }
    }
}
