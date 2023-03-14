namespace Raiding.Heroes.Healers
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name)
        {
            Power = 80;
        }

        public override string CastAbility()
        {
            return $"Druid - {Name} healed for {Power}";
        }
    }
}
