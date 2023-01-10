using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            usernames = usernames.Where(c => c.Length >= 3 && c.Length <= 16).ToArray();

            List<string> validUsernames = new List<string>();
            foreach (var username in usernames)
            {
                string validUsername = "";

                foreach (var chr in username)
                {
                    if (chr == '-' || chr == '_' || char.IsLetterOrDigit(chr))
                    {
                        validUsername += chr;
                    }
                }

                if (validUsername.Length == username.Length)
                {
                    validUsernames.Add(validUsername);
                }
            }

            foreach (var username in validUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}