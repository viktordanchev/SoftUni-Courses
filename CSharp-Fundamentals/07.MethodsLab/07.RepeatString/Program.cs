using System;

namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());

            string result = RepeatedString(input, times);
            Console.WriteLine(result);
        }

        static string RepeatedString(string input, int times)
        {
            string result = "";

            for (int i = 1; i <= times; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
