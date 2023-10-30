using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>();
            Homeworks = new List<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        public bool RegisteredOn { get; set; } 

        public DateTime? Birthday { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
