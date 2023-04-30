using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                if (input.Contains("Play"))
                {
                    queue.Dequeue();
                }
                else if (input.Contains("Add"))
                {
                    string song = input.Substring(4);

                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                        input = Console.ReadLine();
                        continue;
                    }

                    queue.Enqueue(song);
                }
                else
                {
                    Console.WriteLine(string.Join(", ", queue));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
