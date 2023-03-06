using System;

namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsabersSum = lightsaberPrice * (Math.Ceiling((double)studentsCount / 100 * 10) + studentsCount);
            int freeBelts = studentsCount / 6;
            double beltsSum = beltPrice * (studentsCount - freeBelts);
            double robesSum = robePrice * studentsCount;

            double result = lightsabersSum + robesSum + beltsSum;

            if (money >= result)
            {
                Console.WriteLine($"The money is enough - it would cost {result:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {result - money:f2}lv more.");
            }
        }
    }
}
