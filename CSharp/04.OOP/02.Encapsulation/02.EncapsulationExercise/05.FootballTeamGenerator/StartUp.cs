using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            string input = Console.ReadLine();

            while(input != "END")
            {
                string[] data = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string teamName = data[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            Team newTeam = new(teamName);
                            teams.Add(newTeam);
                            break;
                        case "Add":
                            string playerName = data[2];
                            int endurance = int.Parse(data[3]);
                            int sprint = int.Parse(data[4]);
                            int dribble = int.Parse(data[5]);
                            int passing = int.Parse(data[6]);
                            int shooting = int.Parse(data[7]);

                            Team team = GetTeam(teams, teamName);
                            team.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                            break;
                        case "Remove":
                            playerName = data[2];

                            team = GetTeam(teams, teamName);
                            team.RemovePlayer(playerName);
                            break;
                        case "Rating":
                            team = GetTeam(teams, teamName);
                            Console.WriteLine($"{teamName} - {team.Rating:f0}");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }

        static Team GetTeam(List<Team> teams, string teamName)
        {
            Team currTeam = teams.FirstOrDefault(t => t.Name == teamName);

            if (currTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            return currTeam;
        }
    }
}
