using System;
using System.Collections.Generic;
using System.Text;

namespace Entities2
{
    public class Dog :Pet
    {
        public string FavouriteFood { get; set; }

        public Dog(string name, string type, int age, string food) : base(name, type, age)
        {
            FavouriteFood = food;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"PET NAME: {Name}, TYPE:{Type}, AGE:{Age}, FAVE FOOD: {FavouriteFood}");
        }
    }

}
