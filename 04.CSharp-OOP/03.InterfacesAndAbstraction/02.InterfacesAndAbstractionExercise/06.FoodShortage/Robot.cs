using _06.FoodShortage.Interfaces;

namespace _05.BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; }
        public string Id { get; }
    }
}
