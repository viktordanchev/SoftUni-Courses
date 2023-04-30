namespace Raiding.Heroes.Healers
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
        {
            return $"Paladin - {Name} healed for {Power}";
        }
    }
}
