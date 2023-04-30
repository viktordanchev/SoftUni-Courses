using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int l = 1; l <= 9; l++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int n = 1; n <= 9; n++)
                        {
                            if (num % i == 0 && num % l == 0 && num % k == 0 && num % n == 0)
                            {
                                Console.Write($"{i}{l}{k}{n}" + " ");
                            }
                        }
                    }
                }
            }
        }
    }
}
