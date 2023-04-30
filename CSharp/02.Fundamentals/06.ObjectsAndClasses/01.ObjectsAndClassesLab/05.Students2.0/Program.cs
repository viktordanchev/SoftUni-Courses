using System;
using System.Collections.Generic;

namespace _05.Students2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] information = Console.ReadLine().Split(' ');
            List<Student> students = new List<Student>();
            int originalCount = students.Count;

            while (information[0] != "end")
            {
                CheckIfCurrStudentIsOnTheList(students, information);

                Student student = new Student();
                student.FirstName = information[0];
                student.LastName = information[1];
                student.Age = (int.Parse(information[2]));
                student.HomeTown = information[3];

                students.Add(student);

                information = Console.ReadLine().Split(' ');
            }

            string homeTown = Console.ReadLine();

            CheckEveryStudent(homeTown, students);
        }

        static List<Student> CheckIfCurrStudentIsOnTheList(List<Student> students, string[] information)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].FirstName == information[0] && students[i].LastName == information[1])
                {
                    students.Remove(students[i]);
                }
            }
            
            return students;
        }

        static void CheckEveryStudent(string homeTown, List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.HomeTown == homeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
