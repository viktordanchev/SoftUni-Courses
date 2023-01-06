using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currString = Console.ReadLine();
            
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < currString.Length; i++)
            {
                if (i + 1 == currString.Length)
                {
                    sb.Append(currString[i]);
                    break;
                }

                if (currString[i] != currString[i + 1])
                {
                    sb.Append(currString[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}