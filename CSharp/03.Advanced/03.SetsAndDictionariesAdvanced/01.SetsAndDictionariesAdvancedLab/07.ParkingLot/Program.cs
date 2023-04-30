using System;
using System.Collections;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ");

            while (input[0] != "END")
            {
                string direction = input[0];
                string carNumber = input[1];

                switch (direction)
                {
                    case "IN":
                        carNumbers.Add(carNumber);
                        break;
                    case "OUT":
                        carNumbers.Remove(carNumber);
                        break;
                }

                input = Console.ReadLine().Split(", ");
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var carNumber in carNumbers)
            {
                Console.WriteLine(carNumber);
            }
        }
    }
}