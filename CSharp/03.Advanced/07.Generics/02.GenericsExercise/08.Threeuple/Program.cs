using System;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = input[0] + ' ' + input[1];
            string address = input[2];
            string town = input.Length > 4 ? input[3] + ' ' + input[4] : input[3];
            var firstTuple = new Threeuple<string, string, string>(name, address, town);

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            name = input[0];
            int litersOfBeer = int.Parse(input[1]);
            string drunkOrNot = input[2];
            bool isDrunk = drunkOrNot == "drunk" ? true : false;
            var secondTuple = new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk);

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            name = input[0];
            double doubleNum = double.Parse(input[1]);
            string bankName = input[2];
            var thirdTuple = new Threeuple<string, double, string>(name, doubleNum, bankName);

            Console.WriteLine($"{firstTuple.FirstObj} -> {firstTuple.SecondObj} -> {firstTuple.ThirdObj}");
            Console.WriteLine($"{secondTuple.FirstObj} -> {secondTuple.SecondObj} -> {secondTuple.ThirdObj}");
            Console.WriteLine($"{thirdTuple.FirstObj} -> {thirdTuple.SecondObj} -> {thirdTuple.ThirdObj}");
        }
    }
}