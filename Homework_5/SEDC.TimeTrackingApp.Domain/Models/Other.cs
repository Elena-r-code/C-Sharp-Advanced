using SEDC.TimeTrackingApp.Domain.Enums;
using System;

namespace SEDC.TimeTrackingApp.Domain.Models
{
    public class Other
    {
        public string Type { get; set; }
        public Activities Activity { get; set; }

        public Other()
        {
            Type = "Other Hobbies";
            Activity = Activities.Other;
        }

        public void OtheHobbiesActive()
        {
            Console.WriteLine("What is you other hobby?");
            string answer = Console.ReadLine();
            Console.WriteLine($"Started {answer}");
        }
    }
}
