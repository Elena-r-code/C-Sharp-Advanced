using SEDC.TimeTrackingApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Domain.Models
{
    public class Other
    {
        public string Type { get; set; }
        public Activities Activity { get; set; }
        public List<string> ListOfHobbies { get; set; }

        public Other()
        {
            Type = "Other Hobbies";
            Activity = Activities.Other;
        }

        public void OtheHobbiesActive(User user)
        {
            List<string> ListOfHobbies = new List<string>();
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("What is you other hobby?");
                string answer = Console.ReadLine();
               
                if (answer == "")
                {
                    flag = false;
                }
                ListOfHobbies.Add(answer);
            }
            List<string> HobbiesList = ListOfHobbies.Distinct().ToList();
            user.ListOfHobbies = HobbiesList;
            StopwatchForOther(user);

        }


        public void StopwatchForOther(User user)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("When you are done, and want to stop counting the time, press Enter");
            string finish = Console.ReadLine();
            if (finish == "")
            {
                stopwatch.Stop();
                TimeSpan time = stopwatch.Elapsed;
                double convertedTime = Convert.ToDouble(time.TotalSeconds);
                user.OtherHobbiesTime += convertedTime / 60;
                Console.WriteLine($"Time spent on this activity: {Math.Round(convertedTime / 60, 2)} min.");
                Console.WriteLine("Press any key to go back to the Main Menu.");
                Console.ReadKey();
            }
        }
    }
    
}
