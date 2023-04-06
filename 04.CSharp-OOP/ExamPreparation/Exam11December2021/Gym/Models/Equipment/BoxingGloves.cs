namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double BoxingGlovesWeight = 227;
        private const decimal BoxingGlovesPrice = 120m;

        public BoxingGloves() 
            : base(BoxingGlovesWeight, BoxingGlovesPrice)
        {
        }
    }
}
