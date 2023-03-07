using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] allPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] allProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allPeople.Length; i++)
            {
                string[] nameAndMoney = allPeople[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = nameAndMoney[0];
                decimal money = decimal.Parse(nameAndMoney[1]);

                try
                {
                    Person person = new(name, money);
                    people.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            for (int i = 0; i < allProducts.Length; i++)
            {
                string[] nameAndCost = allProducts[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = nameAndCost[0];
                decimal cost = decimal.Parse(nameAndCost[1]);

                try
                {
                    Product product = new(name, cost);
                    products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = data[0];
                string productName = data[1];

                Person person = people.Find(p => p.Name == personName);
                Product product = products.Find(p => p.Name == productName);

                if (person != null && product != null)
                {
                    person.Buy(product);
                }

                command = Console.ReadLine();
            }

            foreach (var person in people) 
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
