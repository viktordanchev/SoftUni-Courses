using System;
using System.Diagnostics.Tracing;

namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isPassContainNecessaryChars = CheckIfPassContainNecessaryChars(password);
            bool isPassContainOnlyLettersAndNums = CheckIfPassContainOnlyLettersAndNums(password);
            bool isPassContainTwoDigits = CheckIfPassContainTwoDigits(password);

            if (!isPassContainNecessaryChars)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!isPassContainOnlyLettersAndNums)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isPassContainTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isPassContainNecessaryChars && isPassContainOnlyLettersAndNums && isPassContainTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckIfPassContainNecessaryChars(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }

            return true;
        }

        static bool CheckIfPassContainOnlyLettersAndNums(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckIfPassContainTwoDigits(string password)
        {
            int counter = 0;

            foreach (char letter in password)
            {
                if (letter >= 48 && letter <= 57)
                {
                    counter++;
                }
            }

            if (counter < 2)
            {
                return false;
            }

            return true;
        }
    }
}
