using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Classes
{
    public class Dog : Animal, IDog
    {
        public string Race { get; set; }
        public string EyeColor { get; set; }

        public Dog(string name, string color, int age, string race, string eyeColor) : base(name, color, age)
        {
            Race = race;
            EyeColor = eyeColor;
        }
        public void Bark()
        {
            Console.WriteLine("bark bark");
        }
    }
}
