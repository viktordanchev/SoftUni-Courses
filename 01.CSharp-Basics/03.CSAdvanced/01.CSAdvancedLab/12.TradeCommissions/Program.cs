using System;

namespace _12.TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double commissionRate = 0;

            switch (city)
            {
                case "Sofia":
                    if (sales >= 0 && sales <= 500)
                    {
                        commissionRate = 5;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commissionRate = 7;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commissionRate = 8;
                    }
                    else if (sales > 10000)
                    {
                        commissionRate = 12;
                    }
                    break;
                case "Varna":
                    if (sales >= 0 && sales <= 500)
                    {
                        commissionRate = 4.5;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commissionRate = 7.5;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commissionRate = 10;
                    }
                    else if (sales > 10000)
                    {
                        commissionRate = 13;
                    }
                    break;
                case "Plovdiv":
                    if (sales >= 0 && sales <= 500)
                    {
                        commissionRate = 5.5;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commissionRate = 8;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commissionRate = 12;
                    }
                    else if(sales > 10000)
                    {
                        commissionRate = 14.5;
                    }
                    break;
            }

            if (commissionRate != 0)
            {
                Console.WriteLine($"{sales / 100 * commissionRate:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
