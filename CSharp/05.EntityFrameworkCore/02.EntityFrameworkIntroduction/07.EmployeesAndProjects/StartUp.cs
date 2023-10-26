using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var output = GetEmployeesInPeriod(context);
            Console.WriteLine(output);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var dataString = new StringBuilder();

            var employees = context.Employees
                .Take(10)
                .Include(e => e.Manager)
                .Include(e => e.EmployeesProjects)
                .ToArray();

            for (int i = 0; i < 10; i++)
            {
                var e = employees[i];

                dataString.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");

                if (e.EmployeesProjects.Count > 0)
                {
                    var projects = context.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.EmployeeId,
                            ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate,
                        })
                        .Where(ep => ep.EmployeeId == e.EmployeeId)
                        .ToArray();

                    foreach (var p in projects)
                    {
                        if (p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                        {
                            var enddate = p.EndDate != null ? p.EndDate?.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                            dataString.AppendLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {enddate}");
                        }
                    }
                }
            }

            return dataString.ToString().Trim();
        }
    }
}