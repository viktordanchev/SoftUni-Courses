using System;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = input[0] + ' ' + input[1];
            string address = input[2];
            var firstTuple = new Tuple<string, string>(name, address);

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            name = input[0];
            int litersOfBeer = int.Parse(input[1]);
            var secondTuple = new Tuple<string, int>(name, litersOfBeer);

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int intNum = int.Parse(input[0]);
            double doubleNum = double.Parse(input[1]);
            var thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine($"{firstTuple.FirstObj} -> {firstTuple.SecondObj}");
            Console.WriteLine($"{secondTuple.FirstObj} -> {secondTuple.SecondObj}");
            Console.WriteLine($"{thirdTuple.FirstObj} -> {thirdTuple.SecondObj}");
        }
    }
}