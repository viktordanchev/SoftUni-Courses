using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>();

                box.BoxValue = Console.ReadLine();

                boxes.Add(box);
            }

            string element = Console.ReadLine();

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