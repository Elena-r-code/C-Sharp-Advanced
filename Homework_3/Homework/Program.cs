using Entities;
using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Vehicle vehicle in VehicleDB.vehicles)
            {
                vehicle.PrintVehicle();
                Validator.Validate(vehicle);
            }

            
            Console.ReadLine();
        }
    }
}
