﻿using _05.ExportProductsInRange.DTOs.Export;
using ProductShop.Data;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new ProductShopContext();

            var output = GetProductsInRange(context);

            Console.WriteLine(output);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer == null ? null : string.Concat(p.Buyer.FirstName, " ", p.Buyer.LastName) 
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("Products"));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var productsXml = new StringWriter())
            {
                serializer.Serialize(productsXml, products, ns);
                return productsXml.ToString();
            }
        }
    }
}