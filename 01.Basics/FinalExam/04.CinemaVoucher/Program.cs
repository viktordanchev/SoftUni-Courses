using System;

namespace _04.CinemaVoucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int voucherValue = int.Parse(Console.ReadLine());

            int ticketCounter = 0;
            int productsCounter = 0;

            while (true)
            {
                string pokupka = Console.ReadLine();

                if (pokupka == "End")
                {
                    break;
                }

                if (pokupka.Length > 8)
                {
                    voucherValue -= pokupka[0] + pokupka[1];

                    if (voucherValue <= 0)
                    {
                        break;
                    }

                    ticketCounter++;
                }
                else if (pokupka.Length <= 8)
                {
                    voucherValue -= pokupka[0];

                    if (voucherValue <= 0)
                    {
                        break;
                    }

                    productsCounter++;
                }
            }

            Console.WriteLine($"{ticketCounter}");
            Console.WriteLine($"{productsCounter}");
        }
    }
}
