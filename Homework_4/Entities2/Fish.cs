using System;
using System.Collections.Generic;
using System.Text;

namespace Entities2
{
    public class Fish: Pet
    {
        public string Color { get; set; }
        public int Size { get; set; }

        public Fish(string name, string type, int age, string color, int size) : base(name, type, age)
        {
            Color = color;
            Size = size;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"PET NAME: {Name}, TYPE:{Type}, AGE:{Age}, COLOR: {Color}, SIZE: {Size}");

        }
    }
}
