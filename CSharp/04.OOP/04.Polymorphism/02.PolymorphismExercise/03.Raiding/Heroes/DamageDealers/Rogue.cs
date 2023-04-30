namespace Raiding.Heroes.DamageDealers
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) 
            : base(name)
        {
            Power = 80;
        }

        public override string CastAbility()
        {
            return $"Rogue - {Name} hit for {Power} damage";
        }
    }
}
