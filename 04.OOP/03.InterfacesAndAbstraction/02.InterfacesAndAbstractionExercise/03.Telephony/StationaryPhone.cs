using System;
using System.Linq;
using Telephony.Interfaces;

namespace Telephony
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
