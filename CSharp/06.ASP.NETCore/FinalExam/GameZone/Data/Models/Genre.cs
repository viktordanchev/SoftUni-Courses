using System.ComponentModel.DataAnnotations;

namespace GameZone.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            Games = new List<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Genre.NameMinLength)]
        [MaxLength(DataConstants.Genre.NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Game> Games { get; set; }
    }
}
