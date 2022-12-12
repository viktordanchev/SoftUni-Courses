using System;

namespace _06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSec = double.Parse(Console.ReadLine());
            double metres = double.Parse(Console.ReadLine());
            double secForMeter = double.Parse(Console.ReadLine());

            double timeInSec = metres * secForMeter;
            double forEvery15Meters = Math.Floor(metres / 15) * 12.5;
            double time = forEvery15Meters + timeInSec;

            if (time < recordInSec)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {time:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {time - recordInSec:f2} seconds slower.");
            }
        }
    }
}
