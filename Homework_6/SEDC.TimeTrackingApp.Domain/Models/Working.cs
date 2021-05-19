using SEDC.TimeTrackingApp.Domain.Enums;
using System;
using System.Diagnostics;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Domain.Models
{
    public class Working
    {
        public string Type { get; set; }
        public Activities Activity { get; set; }
        public WrokingEnum WorkingType { get; set; }
        public Working()
        {
            Type = "WORKING";
            Activity = Activities.Working;

        }


        public void WorkingActive(User user)
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You chose working. Now chose one of the following options: \n1) Working from home \n2) Working at the office");
                bool success = int.TryParse(Console.ReadLine(), out int answer);
                if (success)
                {
                    if (answer == 1)
                    {

                        Console.WriteLine("Started working from home.");
                        StopwatchForWorking(WrokingEnum.Home, user);
                        flag = false;
                    }
                    else if (answer == 2)
                    {
                        Console.WriteLine("Started working at the office.");
                        StopwatchForWorking(WrokingEnum.Office, user);
                        flag = false;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input. Please choose one of the options. Try again with pressing any key");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input. Please choose one of the options. Try again with pressing any key");
                    Console.ReadKey();
                }
            }
        }
        public void StopwatchForWorking(WrokingEnum workingType, User user)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Press ENTER to stop.");
            string finish = Console.ReadLine();
            if (finish == "")
            {
                stopwatch.Stop();
                TimeSpan time = stopwatch.Elapsed;
                double convertedTime = Convert.ToDouble(time.TotalSeconds);
                if (workingType == WrokingEnum.Home)
                {
                    user.WorkFromHome += convertedTime / 60;
                }
                if (workingType == WrokingEnum.Office)
                {
                    user.WorkFromOffice += convertedTime / 60;
                }
                user.WorkingTime += convertedTime / 60;
                Console.WriteLine($"The time you spent doing this activity {Type}: {Math.Round(convertedTime / 60, 2)}");
                Console.WriteLine("Press any key to go back to the Main Menu.");
                Console.ReadKey();
            }
        }
    }

}
