using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guestsCapacity = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wastedFood = 0;

            while (guestsCapacity.Count > 0 && plates.Count > 0)
            {
                int guestCapacity = guestsCapacity.Peek();
                int plate = plates.Pop();

                if (guestCapacity > plate)
                {
                    continue;
                }

                guestCapacity = guestsCapacity.Dequeue();

                wastedFood += plate - guestCapacity;
            }

            if (guestsCapacity.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestsCapacity)}");
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            if (wastedFood > 0)
            {
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }
        }
    }
}