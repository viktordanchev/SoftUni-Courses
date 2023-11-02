using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            PlayersStatistics = new List<PlayerStatistic>();
        }

        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public Position Position { get; set; }
        public bool IsInjured { get; set; }
        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
