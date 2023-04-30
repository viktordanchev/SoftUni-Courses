using System;

namespace _11.RefactorVolumeOfPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            Console.Write("Length: ");

            double width = double.Parse(Console.ReadLine());
            Console.Write("Width: ");

            double height = double.Parse(Console.ReadLine());
            Console.Write("Height: ");

            double volume = (length * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");
        }
    }
}
