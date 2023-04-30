using System;

namespace ShoeStore
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var store = new ShoeStore("SportiveNation", 10);

            var shoeOne = new Shoe("Nike", "running", 42.5, "textile");
            var shoeTwo = new Shoe("Salomon", "hiking", 42, "textile");
            var shoeThree = new Shoe("Reebok", "running", 38, "textile");
            var shoeFour = new Shoe("LaCoste", "casual", 40.5, "leather");
            var shoeFive = new Shoe("Adidas", "casual", 39, "textile");
            var shoeSix = new Shoe("Nike", "hiking", 42.5, "textile");
            var shoeSeven = new Shoe("Adidas", "casual", 42, "leather");
            var shoeEight = new Shoe("AirJordan", "running", 42, "leather");
            var shoeNine = new Shoe("CalninKlein", "casual", 41.5, "leather");
            var shoeTen = new Shoe("Puma", "hiking", 42, "textile");
            var shoeEleven = new Shoe("Skechers", "casual", 42.5, "leather");

            Console.WriteLine(store.AddShoe(shoeOne));
            Console.WriteLine(store.AddShoe(shoeTwo));
            Console.WriteLine(store.AddShoe(shoeThree));
            Console.WriteLine(store.AddShoe(shoeFour));
            Console.WriteLine(store.AddShoe(shoeFive));
            Console.WriteLine(store.AddShoe(shoeSix));
            Console.WriteLine(store.AddShoe(shoeSeven));
            Console.WriteLine(store.AddShoe(shoeEight));
            Console.WriteLine(store.AddShoe(shoeNine));
            Console.WriteLine(store.AddShoe(shoeTen));
            Console.WriteLine(store.AddShoe(shoeEleven));

            var runningShoes = store.GetShoesByType("Running");
            var hikingShoes = store.GetShoesByType("hIKING");

            Console.WriteLine(string.Join($"{Environment.NewLine}", runningShoes));

            Console.WriteLine(string.Join($"{Environment.NewLine}", hikingShoes));

            Console.WriteLine(store.RemoveShoes("leather"));

            var shoeBySize = store.GetShoeBySize(42.5);
            Console.WriteLine(shoeBySize);

            Console.WriteLine(store.StockList(42, "hiking"));
        }
    }
}