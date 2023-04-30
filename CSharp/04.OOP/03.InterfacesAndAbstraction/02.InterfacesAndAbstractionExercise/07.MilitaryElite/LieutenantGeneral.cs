using MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
        }

        public List<Private> Privates { get; }

        public void AddPrivate(Private currPrivate)
        {
            Privates.Add(currPrivate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Privates: {Privates}");

            return sb.ToString().Trim();
        }
    }
}
