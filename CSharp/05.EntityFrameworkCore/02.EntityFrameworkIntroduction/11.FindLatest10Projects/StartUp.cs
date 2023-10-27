using SoftUni.Data;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            var output = GetLatestProjects(context);

            Console.WriteLine(output);
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderBy(p => p.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var p in projects)
            {
                result.AppendLine(p.Name);
                result.AppendLine(p.Description);
                result.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return result.ToString().Trim();
        }
    }
}