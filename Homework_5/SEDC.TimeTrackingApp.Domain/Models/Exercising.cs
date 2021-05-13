using SEDC.TimeTrackingApp.Domain.Enums;
using System;

namespace SEDC.TimeTrackingApp.Domain.Models
{
    public class Exercising
    {
        public string Type { get; set; }
        public Activities Activity { get; set; }
        public Exercising()
        {
            Type = "Exercising";
            Activity = Activities.Exercising;
        }

        public bool ExercisingActive()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("To start exercising choose an option : \n 1)General \n2) Running \n3) Sport");
                bool success = int.TryParse(Console.ReadLine(), out int answer);
                if (success)
                {
                    if (answer == 1)
                    {
                        Console.WriteLine("Started General exercising.");
                        return false;
                    }

                    else if (answer == 2)
                    {
                        Console.WriteLine("Started Running exercising.");
                        return false;
                    }

                    else if (answer == 3)
                    {
                        Console.WriteLine("Started Sport exercising.");
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
