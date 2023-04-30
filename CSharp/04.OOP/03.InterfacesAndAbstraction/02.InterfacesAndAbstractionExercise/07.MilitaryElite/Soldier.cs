using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
