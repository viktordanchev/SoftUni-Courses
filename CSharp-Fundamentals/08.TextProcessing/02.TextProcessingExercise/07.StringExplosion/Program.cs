using System;
using System.Text;

namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            int stregth = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char curChar = input[i];

                if (curChar == '>')
                {
                    stregth += input[i + 1] - '0';
                    sb.Append(curChar);
                }
                else if (stregth == 0)
                {
                    sb.Append(curChar);
                }
                else 
                {
                    stregth--;
                }
            }

            Console.WriteLine(sb);
        }
    }
}