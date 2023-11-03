using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        public int SongId { get; set; }

        [Required]
        [ForeignKey(nameof(SongId))]
        public Song Song { get; set; }

        public int PerformerId { get; set; }

        [Required]
        [ForeignKey(nameof(PerformerId))]
        public Performer Performer { get; set; }
    }
}
