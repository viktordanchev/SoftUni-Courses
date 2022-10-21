using System;

namespace _08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearlyFeeForBasketballTraining = int.Parse(Console.ReadLine());

            double percentCutForShoes = yearlyFeeForBasketballTraining * (40 / 100.0);
            double priceForShoes = yearlyFeeForBasketballTraining - percentCutForShoes;
            double percentCutForOutfit = priceForShoes * (20 / 100.0);
            double priceForOutfit = priceForShoes - percentCutForOutfit;
            double priceForBall = priceForOutfit * (25 / 100.0);
            double priceForAccessories = priceForBall * (20 / 100.0);
            double totalSum = priceForShoes + priceForOutfit + priceForBall + priceForAccessories + yearlyFeeForBasketballTraining;

            Console.WriteLine(totalSum);
        }
    }
}
