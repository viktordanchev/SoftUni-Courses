using System;

namespace _04.CookiesProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = new CookiesProblem();
            Console.WriteLine(n.Solve(10, new int[] { 1, 1, 1, 1 }));
        }
    }
}
