using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Category.NameMinLength)]
        [MaxLength(DataConstants.Category.NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
    } 
}
