using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        private List<string> allowedDelicacieTypes = new List<string>() { "Gingerbread", "Stolen" };
        private List<string> allowedCocktailTypes = new List<string>() { "Hibernation", "MulledWine" };
        private List<string> allowedCocktailSizes = new List<string>() { "Small", "Middle", "Large" };

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothsCount = booths.Models.Count;
            Booth booth = new Booth(boothsCount + 1, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail = null;

            if (!allowedCocktailTypes.Any(c => c == cocktailTypeName))
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);

            if (!allowedCocktailSizes.Any(c => c == size))
                return string.Format(OutputMessages.InvalidCocktailSize, size);

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            if (cocktailTypeName == "Hibernation")
                cocktail = new Hibernation(cocktailName, size);
            else if (cocktailTypeName == "MulledWine")
                cocktail = new MulledWine(cocktailName, size);

            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            IDelicacy delicacy = null;

            if (!allowedDelicacieTypes.Any(d => d == delicacyTypeName))
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            if (delicacyTypeName == "Gingerbread")
                delicacy = new Gingerbread(delicacyName);
            else if (delicacyTypeName == "Stolen")
                delicacy = new Stolen(delicacyName);

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            booth.Charge();
            booth.ChangeStatus();

            return string.Format(OutputMessages.GetBill, $"{booth.Turnover:f2}") +
                Environment.NewLine +
                string.Format(OutputMessages.BoothIsAvailable, boothId);
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);

            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            double orderAmount = 0;
            bool isCocktail = false;
            string[] data = order.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = data[0];
            string itemName = data[1];
            string size = string.Empty;
            int countOfTheOrderedPieces = int.Parse(data[2]);

            if (allowedCocktailTypes.Any(c => c == itemTypeName))
            {
                size = data[3];
                isCocktail = true;
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (!allowedCocktailTypes.Any(c => c == itemTypeName) && !allowedDelicacieTypes.Any(d => d == itemTypeName))
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);

            if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName) && !booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);

            if (isCocktail)
            {
                if(!allowedCocktailTypes.Any(c => c == itemTypeName) ||
                    !booth.CocktailMenu.Models.Any(c => c.Name == itemName && c.Size == size))
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);

                orderAmount = countOfTheOrderedPieces * booth.CocktailMenu.Models.First(c => c.Name == itemName).Price;

                booth.UpdateCurrentBill(orderAmount);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfTheOrderedPieces, itemName);
            }

            if (!allowedDelicacieTypes.Any(c => c == itemTypeName) ||
                     !booth.DelicacyMenu.Models.Any(c => c.Name == itemName))
                return string.Format(OutputMessages.DelicacyStillNotAdded, size, itemName);

            orderAmount = countOfTheOrderedPieces * booth.DelicacyMenu.Models.First(c => c.Name == itemName).Price;

            booth.UpdateCurrentBill(orderAmount);
            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfTheOrderedPieces, itemName);
        }
    }
}