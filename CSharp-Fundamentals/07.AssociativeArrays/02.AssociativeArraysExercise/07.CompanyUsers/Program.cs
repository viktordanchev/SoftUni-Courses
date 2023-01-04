using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyById = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" -> ");
            while (input[0] != "End")
            {
                string companyName = input[0];
                string id = input[1];

                if (!companyById.ContainsKey(companyName))
                {
                    companyById.Add(companyName, new List<string>());
                }

                int counter = 0;
                foreach (var currId in companyById[companyName])
                {
                    if (currId == id)
                    {
                        counter++;
                        break;
                    }
                }

                if (counter == 0)
                {
                    companyById[companyName].Add(id);
                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var company in companyById)
            {
                Console.WriteLine($"{company.Key}");

                Console.WriteLine($"-- {string.Join(Environment.NewLine, companyById[company.Key])}");
            }
        }
    }
}
