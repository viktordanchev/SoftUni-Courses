using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.HelloSoftUni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ThreeSum(new int[] { 0, 3, 0, 1, 1, -1, -5, -5, 3, -3, -3, 0 }));
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for (int f = 0; f < nums.Length; f++)
            {
                for (int s = f + 1; s < nums.Length; s++)
                {
                    for (int t = s + 1; t < nums.Length; t++)
                    {
                        var currList = new List<int> { nums[f], nums[s], nums[t] };
                        currList.Sort();

                        if (nums[f] + nums[s] + nums[t] == 0 &&
                            result.All(l => !l.SequenceEqual(currList)))
                        {
                            result.Add(currList);
                        }
                    }
                }
            }

            return result;
        }
    }
}
