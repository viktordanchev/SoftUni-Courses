namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        private const double SubjectRate = 1;

        public EconomicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, SubjectRate)
        {
        }
    }
}
