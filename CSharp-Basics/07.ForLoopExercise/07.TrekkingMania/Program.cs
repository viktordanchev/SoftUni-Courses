using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfGroups = int.Parse(Console.ReadLine());
            double sum = 0;
            double percent = 0;
            int musala = 0;
            int monblan = 0;
            int kiliman = 0;
            int k2 = 0;
            int everest = 0;

            for (int i = 1; i <= numOfGroups; i++)
            {
                int numOfPeopleInGroup = int.Parse(Console.ReadLine());
                sum += numOfPeopleInGroup;

                if (numOfPeopleInGroup <= 5)
                {
                    musala += numOfPeopleInGroup;
                }
                else if (numOfPeopleInGroup <= 12)
                {
                    monblan += numOfPeopleInGroup;
                }
                else if (numOfPeopleInGroup <= 25)
                {
                    kiliman += numOfPeopleInGroup;
                }
                else if (numOfPeopleInGroup <= 40)
                {
                    k2 += numOfPeopleInGroup;
                }
                else if (numOfPeopleInGroup >= 41)
                {
                    everest += numOfPeopleInGroup;
                }
            }

            percent = (musala / sum) * 100;
            Console.WriteLine($"{percent:f2}%");
            percent = (monblan / sum) * 100;
            Console.WriteLine($"{percent:f2}%");
            percent = (kiliman / sum) * 100;
            Console.WriteLine($"{percent:f2}%");
            percent = (k2 / sum) * 100;
            Console.WriteLine($"{percent:f2}%");
            percent = (everest / sum) * 100;
            Console.WriteLine($"{percent:f2}%");
        }
    }
}
