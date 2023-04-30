using System;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }

        public override double CalculateArea()
            => Math.PI * (Radius * Radius);

        public override double CalculatePerimeter()
            => 2 * Math.PI * Radius;

        public override string Draw()
            => $"Drawing {GetType().Name}";
    }
}
