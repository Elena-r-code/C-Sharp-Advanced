using System;
using System.Collections.Generic;
using System.Text;

namespace Entities1
{
    public static class ExtenstionMethod
    {

        //public static void PrintInfo(this Shape shapes) => Console.WriteLine($"INFO: \n ID: {shapes.Id}, TYPE : {shapes.GetType()}");

        public static void PrintInfo(this Shape shapes)
        {
            if (shapes.GetType().ToString() == "Entities1.Circle")
            {
                Console.WriteLine($"INFO: \n ID: {shapes.Id}, TYPE: CIRCLE");
           }
            else if (shapes.GetType().ToString() == "Entities1.Rectangle")
            {
                Console.WriteLine($"INFO: \n ID: {shapes.Id}, TYPE: RECTANGLE");

            }
        }
    }
}
