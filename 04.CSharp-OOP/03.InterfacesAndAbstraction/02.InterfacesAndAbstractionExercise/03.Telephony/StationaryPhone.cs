using System;
using System.Linq;
using _03.Telephony.Interfaces;

namespace _03.Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public void Dialing(string phoneNumber)
        {
            if (phoneNumber.Any(c => char.IsLetter(c)))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Dialing... {phoneNumber}");
        }
    }
}
