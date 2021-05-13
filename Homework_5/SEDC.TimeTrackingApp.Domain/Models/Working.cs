using SEDC.TimeTrackingApp.Domain.Enums;
using System;

namespace SEDC.TimeTrackingApp.Domain.Models
{
    public class Working
    {
        public string Type { get; set; }
        public Activities Activity { get; set; }
        public Working()
        {
            Type = "Working";
            Activity = Activities.Working;
        }
    

    public bool WorkingActive()
    {
            while (true)
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
                        return false;
                    }
                    else if (answer == 2)
                    {
                        Console.WriteLine("Started working at the office.");
                        return false;
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
    }
}
