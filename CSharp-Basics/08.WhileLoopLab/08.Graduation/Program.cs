using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double sum = 0;
            int grade = 1;
            int counter = 0;

            while (grade <= 12)
            {
                double yerlyGrade = double.Parse(Console.ReadLine());

                if (yerlyGrade < 4)
                {
                    counter++;
                    if (counter == 2)
                    {
                        break;
                    }
                    continue;

                }

                sum += yerlyGrade;
                grade++;
            }

            double averageSum = sum / 12;
            if (grade > 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageSum:f2}");

            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {grade} grade");

            }
        }
    }
}
