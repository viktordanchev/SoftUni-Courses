using GameZone.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models.Games
{
    public class AllViewModel
    {
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
        public string Publisher { get; set; } = null!;

        [Required]
        public string ReleasedOn { get; set; } = null!;

        [Required]
        public string Genre { get; set; } = null!;
    }
}
