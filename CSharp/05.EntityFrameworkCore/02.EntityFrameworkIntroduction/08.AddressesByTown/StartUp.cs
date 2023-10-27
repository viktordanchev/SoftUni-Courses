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
            var output = GetAddressesByTown(context);

            Console.WriteLine(output);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(x => x.Employees)
                .Include(x => x.Town)
                .OrderByDescending(address => address.Employees.Count)
                .ThenBy(address => address.Town.Name)
                .Take(10)
                .ToList();

            var result = new StringBuilder();

            foreach (var a in addresses)
            {
                result.AppendLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count}");
            }

            return result.ToString().Trim();
        }
    }
}