using System;

namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 5.50)
            {
                double area;
                double side;
                double radius;
                double height;
                double length;
                string type = Console.ReadLine();

                if (type == "square")
                {
                    length = double.Parse(Console.ReadLine());

                    area = length * length;

                    Console.WriteLine($"{area:f3}");
                }
                else if (type == "rectangle")
                {
                    length = double.Parse(Console.ReadLine());
                    height = double.Parse(Console.ReadLine());

                    area = length * height;

                    Console.WriteLine($"{area:f3}");
                }
                else if (type == "circle")
                {
                    radius = double.Parse(Console.ReadLine());

                    area = Math.PI * (radius * radius);

                    Console.WriteLine($"{area:f3}");
                }
                else if (type == "triangle")
                {
                    side = double.Parse(Console.ReadLine());
                    height = double.Parse(Console.ReadLine());

                    area = (side * height) / 2;

                    Console.WriteLine($"{area:f3}");
                }
            }
        }
    }
}
