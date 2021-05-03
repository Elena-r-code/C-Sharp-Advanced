using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Bike : Vehicle
    {
        public string Color { get; set; }

        public Bike(int id, string type, int year, int batch, string color) : base(id, type, year, batch)
        {
            Color = color;
        }
        public void PrintVehicle()
        {
            Console.WriteLine($"This {Color} bike is produced in {YearOfProduction}");
        }
    }
}
