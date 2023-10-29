using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            Students = new List<Student>();
            Resources = new List<Resource>();
            Homeworks = new List<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
