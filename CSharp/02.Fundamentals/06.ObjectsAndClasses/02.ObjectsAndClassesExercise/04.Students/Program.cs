using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfAllStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < countOfAllStudents; i++)
            {
                string[] infoForStudent = Console.ReadLine().Split(' ');

                Student student = new Student(infoForStudent[0], infoForStudent[1], float.Parse(infoForStudent[2]));
                students.Add(student);
            }

            List<Student> orderedListByGrade = students.OrderByDescending(student => student.Grade).ToList();

            foreach (Student student in orderedListByGrade)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, float grade) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }
    }
}
