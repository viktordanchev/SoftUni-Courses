using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] register = Console.ReadLine().Split("-");
                string user = register[0];
                string teamName = register[1];

                Team team = new Team();
                team.User = user;
                team.TeamName = teamName;

                int counter = CheckListForМatches(teams, user, teamName);

                if (counter == 0)
                {
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                    teams.Add(team);
                }
            }

            while (true)
            {
                string[] input= Console.ReadLine().Split("->");

                if (input[0] == "end of assignment")
                {
                    break;
                }

                string user = input[0];
                string teamName = input[1];

                int nameCounter = 0;
                for (int i = 0; i < teams.Count; i++)
                {
                    if (teams[i].TeamName != teamName)
                    {
                        nameCounter++;
                    }
                }

                if (nameCounter == teams.Count)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                int userCounter = 0;
                for (int i = 0; i < teams.Count; i++)
                {
                    if (teams[i].Members.Contains(user) || teams[i].User == user)
                    {
                        Console.WriteLine($"Member {user} cannot join team {teamName}!");
                        userCounter++;
                    }
                }

                if (userCounter == 0)
                {
                    for (int i = 0; i < teams.Count; i++)
                    {
                        if (teams[i].TeamName == teamName) 
                        {
                            teams[i].Members.Add(user);
                        }
                    }
                }
            }

            var completedTeams = teams.Where(x => x.Members.Count > 0);
            var orderedList = completedTeams.OrderByDescending(x => x.Members.Count).ThenBy(y => y.TeamName).ToList();

            string disbandedTeam = "";
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count == 0)
                {
                    disbandedTeam = teams[i].TeamName;
                    teams.RemoveAt(i);
                }
            }

            foreach (Team team in orderedList)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.User}");

                foreach (string member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            Console.WriteLine($"{disbandedTeam}");
        }

        static int CheckListForМatches(List<Team> teams, string user, string teamName)
        {
            int counter = 0;

            for (int currTeam = 0; currTeam < teams.Count; currTeam++)
            {
                if (teams[currTeam].TeamName == teamName)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    counter++;
                }
            }

            for (int currUser = 0; currUser < teams.Count; currUser++)
            {
                if (teams[currUser].User == user)
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    counter++;
                }
            }

            return counter;
        }
    }

    class Team
    {
        public Team()
        {
            this.Members = new List<string>();
        }

        public string User { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }
    }
}
