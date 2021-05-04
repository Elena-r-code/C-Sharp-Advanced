using System;
using System.Collections.Generic;
using System.Text;

namespace Entities2
{
    public class Cat :Pet
    {
        public bool Lazy { get; set; }
        public int LivesLeft { get; set; }

        public Cat(string name, string type, int age, bool lazy, int lives) : base(name, type, age)
        {
            Lazy = lazy;
            LivesLeft = lives;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"PET NAME: {Name}, TYPE:{Type}, AGE:{Age}, LAZY: {Lazy}, LIVES LEFT: {LivesLeft}");

        }
    }
}
