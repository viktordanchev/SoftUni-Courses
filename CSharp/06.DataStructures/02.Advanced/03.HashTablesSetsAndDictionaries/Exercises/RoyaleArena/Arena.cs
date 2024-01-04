namespace RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Arena : IArena
    {
        public int Count => throw new NotImplementedException();

        public void Add(BattleCard card)
        {
            throw new NotImplementedException();
        }

        public void ChangeCardType(int id, CardType type)
        {
            throw new NotImplementedException();
        }

        public bool Contains(BattleCard card)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            throw new NotImplementedException();
        }

        public BattleCard GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}