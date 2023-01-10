using System;
using System.Text;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder encryptedText = new StringBuilder();

            foreach (char chr in text)
            {
                int num = (int)chr + 3;
                encryptedText.Append((char)num);
            }

            Console.WriteLine(encryptedText);
        }
    }
}
