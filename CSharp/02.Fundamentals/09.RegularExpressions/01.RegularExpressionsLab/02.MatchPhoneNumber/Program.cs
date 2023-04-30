using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phoneNumber = Console.ReadLine();
            string pattern = @"\+359(?<separator>[- ])2\k<separator>\d{3}\k<separator>\d{4}\b";

            MatchCollection matches = Regex.Matches(phoneNumber, pattern);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}