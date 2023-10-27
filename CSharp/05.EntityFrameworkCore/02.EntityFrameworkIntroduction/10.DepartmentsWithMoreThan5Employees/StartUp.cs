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
            var output = GetDepartmentsWithMoreThan5Employees(context);

            Console.WriteLine(output);
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(x => x.Employees)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var d in departments)
            {
                result.AppendLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");

                var employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                foreach (var e in employees)
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return result.ToString().Trim();
        }
    }
}