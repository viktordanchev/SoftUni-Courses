namespace P02_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            Players = new List<Player>();
        }

        public int PositionId { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
