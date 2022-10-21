using System;

namespace _02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lowGrades = int.Parse(Console.ReadLine());
            int failedTimes = 0;
            int solvedProblemsCount = 0;
            double sum = 0;
            string lastExam = "";
            bool isFailed = true;

            while (failedTimes < lowGrades)
            {
                string examName = Console.ReadLine();
                if (examName == "Enough")
                {
                    isFailed = false;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    failedTimes++;
                }

                sum += grade;
                solvedProblemsCount++;
                lastExam = examName;
            }

            if (isFailed)
            {
                Console.WriteLine($"You need a break, {lowGrades} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {sum / solvedProblemsCount:f2}");
                Console.WriteLine($"Number of problems: {solvedProblemsCount}");
                Console.WriteLine($"Last problem: {lastExam}");
            }
        }
    }
}
