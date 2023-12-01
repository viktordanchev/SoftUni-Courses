using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        [Required]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        [Required]
        public int FootballerId { get; set; }

        [ForeignKey(nameof(FootballerId))]
        public Footballer Footballer { get; set; } = null!;
    }
}
