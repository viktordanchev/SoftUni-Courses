using SeminarHub.Data;
using SeminarHub.Models.Categories;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.Seminars
{
    public class SeminarAddViewModel
    {
        [Required]
        [MinLength(DataConstants.Seminar.TopicMinLength)]
        [MaxLength(DataConstants.Seminar.TopicMaxLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.Seminar.LecturerMinLength)]
        [MaxLength(DataConstants.Seminar.LecturerMaxLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.Seminar.DetailsMinLength)]
        [MaxLength(DataConstants.Seminar.DetailsMaxLength)]
        public string Details { get; set; } = null!;

        [Required]
        public string DateAndTime { get; set; } = null!;

        [Range(DataConstants.Seminar.DurationMin, DataConstants.Seminar.DurationMax)]
        public int Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
