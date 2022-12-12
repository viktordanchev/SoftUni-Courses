using System;
using System.Runtime.Intrinsics.Arm;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                bool isPalindrome = CheckIfNumIsPalindrome(input);

                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }
        }

        static bool CheckIfNumIsPalindrome(string input)
        {
            int number = int.Parse(input);
            int rem, reversedNum = 0;
            int temp = number;
        
            while (number > 0)
            {
                rem = number % 10;
                number = number / 10;
                reversedNum = reversedNum * 10 + rem;
            }
        
            if (temp == reversedNum)
            {
                return true;
            }
        
            return false;
        }
    }
}
