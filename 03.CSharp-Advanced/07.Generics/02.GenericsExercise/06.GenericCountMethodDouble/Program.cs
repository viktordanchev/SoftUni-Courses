using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>();

                box.BoxValue = double.Parse(Console.ReadLine());

                boxes.Add(box);
            }

            double element = double.Parse(Console.ReadLine());

            int count = Compare(boxes, element);

            Console.WriteLine(count);
        }

        static int Compare<T>(List<Box<T>> boxes, T element) where T : IComparable<T>
        {
            int count = 0;

            foreach (var box in boxes)
            {
                if (box.BoxValue.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}