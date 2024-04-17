using GameZone.Data;
using GameZone.Models.Genres;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.Games
{
    public class AddViewModel
    {
        public AddViewModel()
        {
            Genres = new List<GenreViewModel>();   
        }

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
        public string ReleasedOn { get; set; } = null!;

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
