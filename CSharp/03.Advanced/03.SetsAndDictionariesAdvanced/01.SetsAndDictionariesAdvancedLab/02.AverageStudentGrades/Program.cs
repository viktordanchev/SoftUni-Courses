using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < students; i++)
            {
                string[] studentAndGrade = Console.ReadLine().Split();
                string name = studentAndGrade[0];
                decimal grade = decimal.Parse(studentAndGrade[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                }

                studentGrades[name].Add(grade);
            }

            foreach (var studentGrade in studentGrades)
            {
                Console.Write($"{studentGrade.Key} -> ");

                foreach (var grade in studentGrade.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {studentGrade.Value.Average():f2})");
            }
        }
    }
}
