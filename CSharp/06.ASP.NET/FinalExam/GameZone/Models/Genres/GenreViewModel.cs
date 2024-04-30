using GameZone.Data;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.Genres
{
    public class GenreViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Genre.NameMinLength)]
        [MaxLength(DataConstants.Genre.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
