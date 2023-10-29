using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        [Required]
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
