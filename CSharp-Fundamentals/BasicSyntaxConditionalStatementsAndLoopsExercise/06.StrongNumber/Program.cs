using System;

namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string numLength = input.ToString();
            int momentSum = 1;
            int sum = 0;
            int currentNum = 0;

            for (int i = 0; i < numLength.Length; i++)
            {
                currentNum = numLength[i] - '0';


                for (int j = 1; j <= currentNum; j++)
                {
                    momentSum *= j;
                }

                sum += momentSum;
                momentSum = 1;
            }

            if (sum == input)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
