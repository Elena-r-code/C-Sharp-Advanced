﻿namespace Bonus
{
   public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string PrintInfo()
        {
            return ($"{FirstName} {LastName} {Age}");
        }
    }
}
