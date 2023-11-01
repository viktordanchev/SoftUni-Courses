using _01.MusicHubDatabase.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01.MusicHubDatabase.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new List<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public Album Album { get; set; }

        [Required]
        public int WriterId { get; set; }

        [ForeignKey(nameof(WriterId))]
        public Writer Writer { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
