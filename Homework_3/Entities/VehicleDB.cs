using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    static public class VehicleDB
    {
        public static List<Vehicle> vehicles { get; set; }
        static VehicleDB()
        {
            Vehicle first = new Vehicle(5, "Car", 2005, 12345);
            Car second = new Car(8, "Car", 2010, 56785, 60, "Germany, Italy");
            Bike third = new Bike(0, "Bike", 2015, 456789, "yellow");

            vehicles = new List<Vehicle>()
            {
                first,
                second,
                third
            };
        }
    }
}
