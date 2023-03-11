using BorderControl.Interfaces;

namespace BorderControl
{
    public class Citizens : IIdentifiable
    {
        public Citizens(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
    }
}
