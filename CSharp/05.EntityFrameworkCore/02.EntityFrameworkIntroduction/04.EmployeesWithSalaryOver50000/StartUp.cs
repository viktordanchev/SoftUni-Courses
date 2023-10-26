using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var output = GetEmployeesWithSalaryOver50000(context);
            Console.WriteLine(output);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var dataString = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var e in employees)
            {
                dataString.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return dataString.ToString().Trim();
        }
    }
}