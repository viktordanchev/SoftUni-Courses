using System;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int numOfPieces = width * length;
            int sum = numOfPieces;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {
                    break;
                }
                int piece = int.Parse(input);

                numOfPieces -= piece;

                if (numOfPieces < 0)
                {
                    break;
                }
            }

            if (numOfPieces < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(numOfPieces)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{numOfPieces} pieces are left.");
            }
        }
    }
}
