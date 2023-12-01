namespace Footballers.DataProcessor
{
    using Castle.Core.Internal;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CoachDto[]), new XmlRootAttribute("Coaches"));
            var coachDtos = (CoachDto[])serializer.Deserialize(new StringReader(xmlString));
            var result = new StringBuilder();

            var validCaoches = new List<Coach>();
            foreach (var coach in coachDtos)
            {
                if (!IsValid(coach)
                    || string.IsNullOrEmpty(coach.Nationality))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var validCoach = new Coach()
                {
                    Name = coach.Name,
                    Nationality = coach.Nationality
                };

                foreach (var footballer in coach.Footballers)
                {
                    if (!IsValid(footballer)
                        || DateTime.Parse(footballer.ContractStartDate) > DateTime.Parse(footballer.ContractEndDate))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validFootballer = new Footballer()
                    {
                        Name = footballer.Name,
                        ContractStartDate = DateTime.Parse(footballer.ContractStartDate),
                        ContractEndDate = DateTime.Parse(footballer.ContractEndDate),
                        BestSkillType = (BestSkillType)footballer.BestSkillType,
                        PositionType = (PositionType)footballer.PositionType
                    };

                    validCoach.Footballers.Add(validFootballer);
                }

                validCaoches.Add(validCoach);
                result.AppendLine(string.Format(SuccessfullyImportedCoach, validCoach.Name, validCoach.Footballers.Count));
            }

            context.Coaches.AddRange(validCaoches);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamDtos = JsonConvert.DeserializeObject<TeamDto[]>(jsonString);

            var existingFootballers = context.Footballers.Select(f => f.Id).ToList();
            var validTeams = new List<Team>();
            var result = new StringBuilder();

            foreach (var team in teamDtos)
            {
                if (!IsValid(team) || team.Trophies == 0) 
                {
                    result.AppendLine(ErrorMessage);
                    continue; 
                }

                var validTeam = new Team()
                {
                    Name = team.Name,
                    Nationality = team.Nationality,
                    Trophies = team.Trophies
                };

                foreach (var footballerId in team.Footballers)
                {
                    if (!existingFootballers.Contains(footballerId))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validTeamFootballer = new TeamFootballer()
                    {
                        Team = validTeam,
                        FootballerId = footballerId
                    };

                    validTeam.TeamsFootballers.Add(validTeamFootballer);
                }

                validTeams.Add(validTeam);
                result.AppendLine(string.Format(SuccessfullyImportedTeam, validTeam.Name, validTeam.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
