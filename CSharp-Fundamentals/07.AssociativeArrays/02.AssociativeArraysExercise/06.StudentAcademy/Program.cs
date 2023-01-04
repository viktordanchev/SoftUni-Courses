using System;
using System.Collections.Generic;

namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentByGrade = new Dictionary<string, List<double>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentByGrade.ContainsKey(name))
                {
                    studentByGrade.Add(name, new List<double>());
                    studentByGrade[name].Add(grade);
                    continue;
                }

                studentByGrade[name].Add(grade);
            }

            foreach (var student in studentByGrade)
            {
                double finalGrade = 0;
                foreach (var grade in student.Value)
                {
                    finalGrade += grade;
                }

                finalGrade = finalGrade / student.Value.Count;

                if (finalGrade >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {finalGrade:f2}");
                }
            }
        }
    }
}
