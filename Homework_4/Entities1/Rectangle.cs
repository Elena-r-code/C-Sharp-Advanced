using System;
using System.Collections.Generic;
using System.Text;

namespace Entities1
{
    public class Rectangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public override double GetArea()
        {
            Console.WriteLine("Area of rectangle : ");

            return SideA * SideB;
        }
        public override double GetPerimeter()
        {
            Console.WriteLine("Perimeter of rectangle : ");

            return (2 * SideA) + (2 * SideB);
        }

    }
}