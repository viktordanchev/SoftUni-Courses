using System.Text;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;

        public Renovator(string name, string type, double rate, int days)
        {
            this.name = name;
            this.type = type;
            this.rate = rate;
            this.days = days;
        }

        public string Name { get { return name; } set { name = value; } }
        public string Type { get { return type; } set { type = value; } }
        public double Rate { get { return rate; } set { rate = value; } }
        public int Days { get { return days; } set { days = value; } }
        public bool Hired { get { return hired; } set { hired = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {name}");
            sb.AppendLine($"--Specialty: {type}");
            sb.AppendLine($"--Rate per day: {rate} BGN");

            return sb.ToString().Trim();
        }
    }
}