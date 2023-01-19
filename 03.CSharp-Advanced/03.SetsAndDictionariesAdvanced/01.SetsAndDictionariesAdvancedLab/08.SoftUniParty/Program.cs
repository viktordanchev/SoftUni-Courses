using System;
using System.Collections.Generic;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuestList = new HashSet<string>();
            HashSet<string> regularGuestList = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuestList.Add(input);
                    input = Console.ReadLine();
                    continue;
                }

                regularGuestList.Add(input);

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuestList.Remove(input);
                }

                regularGuestList.Remove(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(vipGuestList.Count + regularGuestList.Count);

            foreach (var guest in vipGuestList)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}