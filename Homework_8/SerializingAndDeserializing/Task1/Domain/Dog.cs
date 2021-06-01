using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Domain
{
    public class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }

        public Dog(string name, int age, string color)
        {
            Name = name;
            Age = age;
            Color = color;
        }

        public string PrintInfo()
        {
            return $"Name : {Name} , Age : {Age} , Color : {Color}";
        }
    }
}
