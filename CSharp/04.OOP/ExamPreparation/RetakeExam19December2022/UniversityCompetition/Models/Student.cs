using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private List<int> coveredExams;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new List<int>();
            University = new University(0, "test", "Economical", 0, new List<int>());
        }

        public int Id { get; private set; }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);

                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);

                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams { get { return coveredExams.AsReadOnly(); } }

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            University = university;
        }
    }
}
