namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToArray();
            int numbersSum = Sum(numbers, 0);

            Console.WriteLine(numbersSum);
        }

        private static int Sum(int[] numbers, int index)
        {
            if(index + 1 == numbers.Length)
            {
                return numbers[index];
            }

            return numbers[index] + Sum(numbers, index + 1);
        }
    }
}
