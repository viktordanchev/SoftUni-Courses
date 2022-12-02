using System;
using System.Security.Cryptography;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biggerNum = Increment(10, 4);
            Console.WriteLine(biggerNum);
        }

        static int Increment(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }
    }
}
