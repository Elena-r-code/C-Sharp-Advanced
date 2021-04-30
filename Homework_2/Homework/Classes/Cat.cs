using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Classes
{
    public class Cat : Animal, ICat
    {
        public bool IsFat { get; set; }

        public Cat(string name, string color, int age, bool isFat) : base(name, color, age)
        {
            IsFat = isFat;
        }
  

        public void Eat(string food)
        {
            Console.WriteLine( $"This cat {Name} eats {food}");
        }
    }
}
