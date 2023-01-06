using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int digit = int.Parse(Console.ReadLine());

            if (digit == 0 )
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();
            GetSum(sb, number, digit);

            StringBuilder reversedString = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                reversedString.Append(sb[i]);
            }

            Console.WriteLine(reversedString);
        }

        static StringBuilder GetSum(StringBuilder sb, string number, int digit)
        {
            int reminder = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int lastNumber = number[i] - '0';
                int result = lastNumber * digit + reminder;

                sb.Append(result % 10);

                reminder = result / 10;
            }

            if (reminder > 0)
            {
                sb.Append(reminder);
            }

            return sb;
        }
    }
}