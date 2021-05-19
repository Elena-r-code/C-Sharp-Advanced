using SEDC.TimeTrackingApp.Domain.Enums;
using SEDC.TimeTrackingApp.Domain.Models;
using System;
using System.Collections.Generic;

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
        public Activities FavouriteType { get; set; }
        public double WorkFromHome { get; set; }
        public double WorkFromOffice { get; set; }
        public List<string> ListOfHobbies { get; set; }
        public bool AccountActive { get; set; }
        public User(string firstName, string lastName, int age, string username, string password, Activities faveType)
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
            FavouriteType = faveType;
            AccountActive = true;
        }
        
        public override void GetInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine($"WELCOME, {FirstName} {LastName}\n");
        }
    }
}
