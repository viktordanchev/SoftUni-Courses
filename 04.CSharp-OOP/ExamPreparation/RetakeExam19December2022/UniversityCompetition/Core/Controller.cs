using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private List<string> supportedSubjectTypes = new List<string>() { "EconomicalSubject", "HumanitySubject", "TechnicalSubject" };
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            IStudent student = students.FindByName(firstName + " " + lastName);

            if (student != null)
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);

            student = new Student(1 + students.Models.Count, firstName, lastName);
            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (!supportedSubjectTypes.Any(t => t == subjectType))
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);

            ISubject subject = subjects.FindByName(subjectName);

            if (subject != null)
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);

            switch (subjectType)
            {
                case "EconomicalSubject":
                    subject = new EconomicalSubject(1 + subjects.Models.Count, subjectName);
                    break;
                case "HumanitySubject":
                    subject = new HumanitySubject(1 + subjects.Models.Count, subjectName);
                    break;
                case "TechnicalSubject":
                    subject = new TechnicalSubject(1 + subjects.Models.Count, subjectName);
                    break;
            }

            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = universities.FindByName(universityName);

            if (university != null)
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);

            List<int> requiredSubjectsIds = new List<int>();

            foreach (var requiredSubject in requiredSubjects)
            {
                foreach (var subject in subjects.Models)
                {
                    if (subject.Name == requiredSubject)
                        requiredSubjectsIds.Add(subject.Id);
                }
            }

            university = new University(1 + universities.Models.Count, universityName, category, capacity, requiredSubjectsIds);
            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            string firstName = studentName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[0];
            string lastName = studentName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[1];

            if (student == null)
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);

            if (university == null)
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);

            int coveredExams = 0;

            foreach (var subject in university.RequiredSubjects)
            {
                foreach (var exam in student.CoveredExams)
                {
                    if (subject == exam)
                        coveredExams++;
                }
            }

            if (coveredExams != university.RequiredSubjects.Count)
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);

            if (student.University.Name == universityName)
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
                return string.Format(OutputMessages.InvalidStudentId);

            if (subject == null)
                return string.Format(OutputMessages.InvalidSubjectId);

            if (student.CoveredExams.Any(e => e == subjectId))
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            int studentsCount = students.Models.Where(s => s.University.Id == universityId).Count();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString().Trim();
        }
    }
}
