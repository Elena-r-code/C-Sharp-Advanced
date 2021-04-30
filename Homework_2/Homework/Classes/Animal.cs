using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Classes
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }

        public Animal(string name, string color, int age)
        {
            Name = name;
            Color = color;
            Age = age;
        }

        public void PrintAnimal()
        {
            Console.WriteLine($"Name: {Name}, Color: {Color}, Age: {Age}");
        }

        
    }
}
