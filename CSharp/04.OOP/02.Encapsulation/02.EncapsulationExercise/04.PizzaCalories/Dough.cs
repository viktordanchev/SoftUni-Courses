using System;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }

                weight = value;
            }
        }

        public double GetDoughCalories()
        {
            double calories = 0;

            switch (FlourType.ToLower())
            {
                case "white":
                     calories = (2 * Weight) * White;
                    break;
                case "wholegrain":
                    calories = (2 * Weight) * Wholegrain;
                    break;
            }

            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    calories *= Crispy;
                    break;
                case "chewy":
                    calories *= Chewy;
                    break;
                case "homemade":
                    calories *= Homemade;
                    break;
            }

            return calories;
        }
    }
}
