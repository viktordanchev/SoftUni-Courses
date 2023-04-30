using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int BoxerStamina = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, BoxerStamina)
        {
        }

        public override void Exercise()
        {
            if (Stamina + 15 > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }

            Stamina += 15;
        }
    }
}
