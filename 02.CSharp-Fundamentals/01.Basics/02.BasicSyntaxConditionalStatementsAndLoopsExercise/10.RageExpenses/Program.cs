using System;
using System.Diagnostics;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadsetsCount = 0;
            int trashedMousesCount = 0;
            int trashedKeyboardsCount = 0;
            int trashedDisplaysCount = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                bool isHeadsetTrashed = false;
                bool isMouseTrashed = false;

                if (i % 2 == 0)
                {
                    isHeadsetTrashed = true;
                    trashedHeadsetsCount++;
                }

                if (i % 3 == 0)
                {
                    isMouseTrashed = true;
                    trashedMousesCount++;
                }

                if (isMouseTrashed && isHeadsetTrashed)
                {
                    trashedKeyboardsCount++;

                    if (trashedKeyboardsCount % 2 == 0)
                    {
                        trashedDisplaysCount++;
                    }
                }
            }

            double expenses = trashedHeadsetsCount * headsetPrice + trashedMousesCount * mousePrice + trashedKeyboardsCount * keyboardPrice + trashedDisplaysCount * displayPrice;

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
