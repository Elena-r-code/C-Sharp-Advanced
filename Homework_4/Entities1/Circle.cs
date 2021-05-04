using System;
using System.Collections.Generic;
using System.Text;

namespace Entities1
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            Console.WriteLine("Area of circle : ");
            return Radius * 3.14;
        }
        public override double GetPerimeter()
        {
            Console.WriteLine("Perimeter of circle : ");

            return 2 * Radius * 3.14;
        }

    }
}

