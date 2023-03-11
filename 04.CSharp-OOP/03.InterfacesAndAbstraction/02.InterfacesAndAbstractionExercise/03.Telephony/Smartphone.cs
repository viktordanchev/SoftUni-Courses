using System;
using System.Linq;
using _03.Telephony.Interfaces;

namespace _03.Telephony
{
    public class Smartphone : ISmartphone
    {
        public void Calling(string phoneNumber)
        {
            if (phoneNumber.Any(c => char.IsLetter(c)))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {phoneNumber}");
        }

        public void Browsing(string website)
        {
            if (website.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {website}!");
        }
    }
}
