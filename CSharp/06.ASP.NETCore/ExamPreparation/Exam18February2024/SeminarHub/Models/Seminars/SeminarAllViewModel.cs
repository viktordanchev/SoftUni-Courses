using SeminarHub.Data;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.Seminars
{
    public class SeminarAllViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Seminar.TopicMinLength)]
        [MaxLength(DataConstants.Seminar.TopicMaxLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.Seminar.LecturerMinLength)]
        [MaxLength(DataConstants.Seminar.LecturerMaxLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;

        [Required]
        public string DateAndTime { get; set; } = null!;

        [Required]
        public string Organizer { get; set; } = null!;
    }
}
