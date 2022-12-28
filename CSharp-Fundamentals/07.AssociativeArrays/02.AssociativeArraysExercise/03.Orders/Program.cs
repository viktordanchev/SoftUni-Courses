using System;
using System.Collections.Generic;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productByPrice = new Dictionary<string, double>();
            Dictionary<string, int> productByQuantity = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "buy")
            {
                string product = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (!productByQuantity.ContainsKey(product))
                {
                    productByQuantity.Add(product, quantity);
                }
                else
                {
                    productByQuantity[product] += quantity;
                }


                if (!productByPrice.ContainsKey(product))
                {
                    productByPrice.Add(product, price * quantity);
                }
                else
                {
                    productByPrice.Remove(product);
                    productByPrice.Add(product, price * productByQuantity[product]);
                }


                input = Console.ReadLine().Split(' ');
            }

            foreach (var item in productByPrice)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}