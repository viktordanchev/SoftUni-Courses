using CarDealer.Data;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var output = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(output);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("F2"),
                    price = s.Car.PartsCars.Sum(p => p.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100)).ToString("F2")
                })
                .ToArray();

            var salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesJson;
        }
    }
}