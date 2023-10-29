using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            var output = DeleteProjectById(context);

            Console.WriteLine(output);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .Find(2);

            context.EmployeesProjects.RemoveRange(context.EmployeesProjects.Where(ep => ep.Project == project));
            context.Projects.Remove(project);

            context.SaveChanges();

            var result = new StringBuilder();

            var projects = context.Projects
                .Take(10)
                .ToList();

            foreach (var p in projects)
            {
                result.AppendLine(p.Name);
            }

            return result.ToString().Trim();
        }
    }
}