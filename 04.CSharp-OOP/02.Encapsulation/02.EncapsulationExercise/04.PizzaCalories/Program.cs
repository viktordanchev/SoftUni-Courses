using System;
using System.Linq;

namespace _04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            nums = nums.Where(x => x % 2 == 0).ToArray();

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
