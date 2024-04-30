using GameZone.Data;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.Games
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [MinLength(DataConstants.Game.TitleMinLength)]
        [MaxLength(DataConstants.Game.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.Game.DescriptionMinLength)]
        [MaxLength(DataConstants.Game.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ReleasedOn { get; set; } = null!;

        [Required]
        public string Genre { get; set; } = null!;

        [Required]
        public string Publisher { get; set; } = null!;
    }
}
