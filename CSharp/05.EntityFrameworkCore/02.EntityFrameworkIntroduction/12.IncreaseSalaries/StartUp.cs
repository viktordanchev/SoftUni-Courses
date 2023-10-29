using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            var output = IncreaseSalaries(context);

            Console.WriteLine(output);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new List<string>() { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departments.Any(d => d == e.Department.Name));

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var result = new StringBuilder();

            foreach (var e in employees.ToList())
            {
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return result.ToString().Trim();
        }
    }
}