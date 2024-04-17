using GameZone.Data;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.Games
{
    public class JoinedViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Game.TitleMinLength)]
        [MaxLength(DataConstants.Game.TitleMaxLength)]
        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string Publisher { get; set; } = null!;

        [Required]
        public string ReleasedOn { get; set; } = null!;

        [Required]
        public string Genre { get; set; } = null!;
    }
}
