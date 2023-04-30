using MilitaryElite.Interfaces;
using System;

namespace MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, firstName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}" + Environment.NewLine + 
                $"Code Number: {CodeNumber}";
        }
    }
}
