namespace _02.RecursiveDrawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Draw(number);
        }

        private static void Draw(int number)
        {
            if(number == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number)); 

            Draw(number - 1);

            Console.WriteLine(new string('#', number));
        }
    }
}
