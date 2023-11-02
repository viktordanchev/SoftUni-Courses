namespace P02_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            PrimaryKitTeams = new List<Team>();
            SecondaryKitTeams = new List<Team>();
        }

        public int ColorId { get; set; }
        public string Name { get; set; }
        public ICollection<Team> PrimaryKitTeams { get; set; }
        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
