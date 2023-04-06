namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double KettlebellWeight = 10000;
        private const decimal KettlebellPrice = 80m;

        public Kettlebell() 
            : base(KettlebellWeight, KettlebellPrice)
        {
        }
    }
}
