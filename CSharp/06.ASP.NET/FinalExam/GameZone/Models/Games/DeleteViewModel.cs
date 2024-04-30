using GameZone.Data;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.Games
{
    public class DeleteViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Game.TitleMinLength)]
        [MaxLength(DataConstants.Game.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public string Publisher { get; set; } = null!;
    }
}
