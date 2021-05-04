using System;
using System.Collections.Generic;
using System.Text;

namespace Entities1
{
    public static class GenericDb<T> where T : Shape
    {
        public static List<T> Shapes { get; set; }
        static GenericDb()
        {
            Shapes = new List<T>();
        }

        public static void PrintArea()
        {
            foreach (T shape in Shapes)
            {
                Console.WriteLine(shape.GetArea());
            }
        }

        public static void PrintPerimeter()
        {
            foreach (T shape in Shapes)
            {
                Console.WriteLine(shape.GetPerimeter());
            }
        }
    }
}