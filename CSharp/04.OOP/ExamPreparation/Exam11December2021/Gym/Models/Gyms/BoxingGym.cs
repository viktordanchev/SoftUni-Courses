namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int BoxingGymCapacity = 15;

        public BoxingGym(string name) 
            : base(name, BoxingGymCapacity)
        {
        }
    }
}
