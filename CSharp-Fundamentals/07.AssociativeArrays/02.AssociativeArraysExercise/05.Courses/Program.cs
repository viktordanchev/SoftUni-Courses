using System;
using System.Collections.Generic;

namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseByStudent = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" : ");
            while (input[0] != "end")
            {
                string course = input[0];
                string name = input[1];

                if (!courseByStudent.ContainsKey(course))
                {
                    courseByStudent.Add(course, new List<string>());
                    courseByStudent[course].Add(name);
                    input = Console.ReadLine().Split(" : ");
                    continue;
                }

                foreach (var currCourse in courseByStudent)
                {
                    if (currCourse.Key == course)
                    {
                        courseByStudent[course].Add(name);
                    }
                }

                input = Console.ReadLine().Split(" : ");
            }

            foreach (var course in courseByStudent)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var name in course.Value)
                {
                    Console.WriteLine($"-- {name}");
                }        
            }
        }
    }
}