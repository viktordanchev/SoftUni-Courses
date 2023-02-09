using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> pomps = new Queue<int[]>();
            
            int value = int.Parse(Console.ReadLine());

            for (int i = 0; i < value; i++)
            {
                int[] petrolPump = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                pomps.Enqueue(petrolPump);
            }

            int count = 0;

            while (true)
            {
                int[] pomp = pomps.Dequeue();

                int amountPetrol = 0;
                for (int j = 0; j < value; j++)
                {
                    int litres = pomp[0];
                    int distance = pomp[1];

                    amountPetrol += litres - distance;
                    if (amountPetrol < 0)
                    {
                        count++;
                        pomps.Enqueue(pomp);
                        break;
                    }

                    pomps.Enqueue(pomp);
                    pomp = pomps.Dequeue();
                }

                if (amountPetrol > 0)
                {
                    Console.WriteLine(count);
                    break;
                }
            }
        }
    }
}