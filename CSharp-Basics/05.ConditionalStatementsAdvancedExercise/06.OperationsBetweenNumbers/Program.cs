using System;

namespace _06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0;

            if (operation == '+' || operation == '-' || operation == '*')
            {
                if (operation == '+')
                {
                    result = num1 + num2;
                }
                else if (operation == '-')
                {
                    result = num1 - num2;
                }
                else
                {
                    result = num1 * num2;
                }

                string evenOrOdd = "odd";
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }

                Console.WriteLine($"{num1} {operation} {num2} = {result} - {evenOrOdd}");
            }
            else //operation='/' || operation="%"
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    if (operation == '/')
                    {
                        result = 1.0 * num1 / num2;
                        Console.WriteLine($"{num1} {operation} {num2} = {result:f2}");
                    }
                    else //operation="%"
                    {
                        result = num1 % num2;
                        Console.WriteLine($"{num1} {operation} {num2} = {result}");
                    }
                }
            }
        }
    }
}
