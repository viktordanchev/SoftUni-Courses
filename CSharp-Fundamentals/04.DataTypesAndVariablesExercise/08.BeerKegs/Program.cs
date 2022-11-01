using System;
using System.Xml.Schema;

namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            string biggestKeg = "";
            float biggestVolume = 0;

            for (int i = 1; i <= numberOfKegs; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                float currVolume = 3.14f * (radius * radius) * height;

                if (currVolume > biggestVolume)
                {
                    biggestVolume = currVolume;
                    biggestKeg = model;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
