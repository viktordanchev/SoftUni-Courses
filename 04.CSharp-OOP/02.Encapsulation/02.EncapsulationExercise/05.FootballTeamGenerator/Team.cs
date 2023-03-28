using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> team;
        private string name;

        public Team(string name)
        {
            Name = name;
            team = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A name should not be empty.");

                name = value;
            }
        }
        public double Rating
        {
            get
            {
                double rating = 0;

                foreach (var player in team)
                {
                    rating += player.OverallSkillLevel;
                }

                if (team.Count > 0)
                    rating /= team.Count;

                return rating;
            }
        }
        public int NumberOfPlayers { get => team.Count; }

        public void AddPlayer(Player player)
        {
            team.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!team.Any(p => p.Name == playerName))
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");

            Player player = team.First(p => p.Name == playerName);

            team.Remove(player);
        }
    }
}
