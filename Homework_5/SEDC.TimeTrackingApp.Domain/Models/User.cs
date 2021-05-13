using SEDC.TimeTrackingApp.Domain.Models;
using System;

namespace TimeTrackingApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double ReadingTime { get; set; }
        public double ExercisingTime { get; set; }
        public double WorkingTime { get; set; }
        public double OtherHobbiesTime { get; set; }
        public User(string firstName, string lastName, int age, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Password = password;
            ReadingTime = 0;
            ExercisingTime = 0;
            WorkingTime = 0;
            OtherHobbiesTime = 0;
        }
        public override void GetInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine($"WELCOME, {FirstName} {LastName}\n");
        }
    }
}
