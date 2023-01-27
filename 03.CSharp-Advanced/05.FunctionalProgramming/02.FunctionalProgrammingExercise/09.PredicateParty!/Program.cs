using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                switch (command)
                {
                    case "Remmove":
                        break;
                }


                input = Console.ReadLine();
            }
        }
    }
}
