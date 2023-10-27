using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            var output = GetEmployee147(context);

            Console.WriteLine(output);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .FirstOrDefault(e => e.EmployeeId == 147);

            var result = new StringBuilder();

            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            var projects = context.EmployeesProjects
                .Select(ep => new
                {
                    ep.EmployeeId,
                    ProjectName = ep.Project.Name
                })
                .Where(ep => ep.EmployeeId == employee.EmployeeId)
                .OrderBy(ep => ep.ProjectName)
                .ToList();

            foreach (var p in projects)
            {
                result.AppendLine(p.ProjectName);
            }

            return result.ToString().Trim();
        }
    }
}