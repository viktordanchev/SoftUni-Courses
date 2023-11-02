using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
            HomeGames = new List<Game>();
            AwayGames = new List<Game>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Initials { get; set; }
        public decimal Budget { get; set; }
        public int PrimaryKitColorId { get; set; }

        [ForeignKey(nameof(PrimaryKitColorId))]
        public Color PrimaryKitColor { get; set; }
        public int SecondaryKitColorId { get; set; }

        [ForeignKey(nameof(SecondaryKitColorId))]
        public Color SecondaryKitColor { get; set; }
        public int TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        public Town Town { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Game> HomeGames { get; set; }
        public ICollection<Game> AwayGames { get; set; }
    }
}
