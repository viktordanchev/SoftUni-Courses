using Raiding.Heroes.Interfaces;

namespace Raiding.Heroes
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
        public int Power { get; protected set; }
        public abstract string CastAbility();
    }
}
