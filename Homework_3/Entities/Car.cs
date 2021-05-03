using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Car :Vehicle
    {
        public int FuelTank { get; set; }
        public string Countries { get; set; }

        public Car(int id, string type, int year, int batch, int fuel, string countries) : base(id, type, year, batch)
        {
            FuelTank = fuel;
            Countries = countries;
        }

        public void PrintVehicle()
        {
            Console.WriteLine($"The vehicle of type {Type} is produced in {Countries}");
        }
    }
}
