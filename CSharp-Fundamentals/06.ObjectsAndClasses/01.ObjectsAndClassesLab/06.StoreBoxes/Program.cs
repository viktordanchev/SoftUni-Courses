using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(' ');
            List<Box> boxes = new List<Box>();

            while (command[0] != "end")
            {
                Box box = new Box
                {
                    SerialNumber= command[0],
                    ItemQuantity = int.Parse(command[2]),
                    Item = new Item(command[1], double.Parse(command[3]))
                };

                boxes.Add(box);
                command = Console.ReadLine().Split(' ');
            }

            List<Box> orderBoxes = boxes.OrderByDescending(box => box.PriceOfOneBox).ToList();
            
            foreach (Box box in orderBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceOfOneBox:f2}");
            }
        }
    }

    class Item
    {
        public Item(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceOfOneBox
        {
            get
            {
                return this.ItemQuantity * this.Item.Price;
            }
        }
    }
}
