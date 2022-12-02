using System;

namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (operation == "add")
            {
                AddNumbers(firstNumber, secondNumber);
            }
            else if (operation == "multiply")
            {
                MultiplyNumbers(firstNumber, secondNumber);
            }
            else if (operation == "subtract")
            {
                SubtractNumbers(firstNumber, secondNumber);
            }
            else if (operation == "divide")
            {
                DivideNumbers(firstNumber, secondNumber);
            }
        }

        static void DivideNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber / secondNumber);
        }

        static void SubtractNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        static void MultiplyNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        static void AddNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
    }
}
