using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var output = GetEmployeesFromResearchAndDevelopment(context);
            Console.WriteLine(output);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var dataString = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            foreach (var e in employees)
            {
                dataString.AppendLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
            }

            return dataString.ToString().Trim();
        }
    }
}