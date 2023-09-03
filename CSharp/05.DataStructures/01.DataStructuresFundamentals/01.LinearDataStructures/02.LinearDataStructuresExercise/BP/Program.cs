using System;

namespace Problem04.BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BalancedParenthesesSolve t = new BalancedParenthesesSolve();
            Console.WriteLine(t.AreBalanced("())"));
        }
    }
}
