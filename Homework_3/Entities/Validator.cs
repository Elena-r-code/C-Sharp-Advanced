using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    static public class Validator
    {
        public static void Validate(Vehicle vehicle)
        {
            if(vehicle.Id >0 && !string.IsNullOrEmpty(vehicle.Type) && vehicle.YearOfProduction != 0)
                {
                    Console.WriteLine("Successful validation!");
                }
            else
            {
                Console.WriteLine("ERROR!");
            }
        }
    }
}
