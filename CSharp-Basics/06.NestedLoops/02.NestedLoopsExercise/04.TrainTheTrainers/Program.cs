using System;

namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            int rating = 0;
            int ratingAll = 0;
            double sum = 0;
            double sumAll = 0;


            while (true)
            {
                sum = 0;
                rating = 0;
                string presentation = Console.ReadLine();

                if (presentation == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {sumAll / ratingAll:f2}.");
                    break;
                }

                for (int i = 1; i <= jury; i++)
                {

                    ratingAll++;
                    rating++;
                    double grade = double.Parse(Console.ReadLine());

                    sumAll += grade;
                    sum += grade;

                }

                Console.WriteLine($"{presentation} - {sum / rating:f2}.");
            }
        }
    }
}
