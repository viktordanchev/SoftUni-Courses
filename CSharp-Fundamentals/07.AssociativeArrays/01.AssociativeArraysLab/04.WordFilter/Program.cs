using System;

namespace _04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, };
            int[] nums2 = new int[2];

            nums2 = nums;

            Console.WriteLine(string.Join(' ', nums));
            Console.WriteLine(string.Join(' ', nums2));

            nums2[0] = 5;
            nums2[1] = 53;

            Console.WriteLine(string.Join(' ', nums));
            Console.WriteLine(string.Join(' ', nums2));
        }
    }
}
