using System;
using System.Collections.Generic;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] information = Console.ReadLine().Split(' ');
            List<Student> students = new List<Student>();

            while (information[0] != "end")
            {
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
