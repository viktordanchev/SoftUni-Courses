namespace _04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nubmer = int.Parse(Console.ReadLine());
            int factorial = GetFactorial(nubmer);

            Console.WriteLine(factorial);
        }

        static public int GetFactorial(int nubmer)
        {
            if(nubmer == 0)
            {
                return 1;
            }

            return nubmer * GetFactorial(nubmer - 1);
        }
    }
}
