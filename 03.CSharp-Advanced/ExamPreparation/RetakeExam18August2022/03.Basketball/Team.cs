using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public List<Player> Players { get; set; }
        public int Count { get { return Players.Count; } }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Position == null)
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            foreach (var currPlayer in Players)
            {
                if (currPlayer.Name == player.Name)
                {
                    return null;
                }
            }

            Players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {--OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            foreach (var player in Players)
            {
                if (player.Name == name)
                {
                    Players.Remove(player);
                    OpenPositions++;
                    return true;
                }
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removed = 0;

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Position == position)
                {
                    Players.Remove(Players[i]);
                    removed++;
                    OpenPositions++;
                }
            }

            return removed;
        }

        public Player RetirePlayer(string name)
        {
            foreach (var player in Players)
            {
                if (player.Name == name)
                {
                    player.Retired = true;
                    return player;
                }
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            var list = new List<Player>();

            list = Players.Where(p => p.Games >= games).ToList();
            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in Players)
            {
                if (player.Retired == false)
                {
                    sb.AppendLine(player.ToString());
                }
            }

            return sb.ToString();
        }
    }
}