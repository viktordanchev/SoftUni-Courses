namespace Heroes.Models
{
    public class Claymore : Weapon
    {
        private const int ClaymoreDamage = 20;

        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (Durability == 0)
                return Durability;

            Durability -= 1;

            return ClaymoreDamage;
        }
    }
}
