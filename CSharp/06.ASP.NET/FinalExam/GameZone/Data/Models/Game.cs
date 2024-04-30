using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models
{
    public class Game
    {
        public Game()
        {
            GamersGames = new List<GamerGame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Game.TitleMinLength)]
        [MaxLength(DataConstants.Game.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.Game.DescriptionMinLength)]
        [MaxLength(DataConstants.Game.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string PublisherId { get; set; } = null!;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public IEnumerable<GamerGame> GamersGames { get; set; }
    }
}
