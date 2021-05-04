using Entities1;
using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericDb<Shape>.Shapes.Add(new Circle() { Id = 5, Radius = 2 });
            GenericDb<Shape>.Shapes.Add(new Rectangle() { Id = 6, SideA = 1.5, SideB = 2.8 });

            foreach (Shape shape in GenericDb<Shape>.Shapes)
            {
                shape.PrintInfo();
            }

            Console.WriteLine("\nAREAS : \n");
            GenericDb<Shape>.PrintArea();

            Console.WriteLine("\nPERIMETERS :\n ");
            GenericDb<Shape>.PrintPerimeter();


            Console.ReadLine();

        }
        
    }
}
