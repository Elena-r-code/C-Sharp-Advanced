using SEDC.TimeTrackingApp.Domain.Enums;
using System;
namespace SEDC.TimeTrackingApp.Domain.Models
{
    public class Reading
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public Activities Activity { get; set; }
        public Reading()
        {
            Title = "Reading";
            Description = "";
            NumberOfPages = 0;

        }

        public bool ReadingActive()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You choose to read. You have the following options: \n 1) Belles Letters \n2) Fiction \n3) Professional Literature ");
                bool success = int.TryParse(Console.ReadLine(), out int answer);
                if (success)
                {
                    if (answer == 1)
                    {
                        Console.WriteLine("You are now reading Belles Letters...");
                        Description = "A piece of prose writing that is belletristic in style is characterized by a casual, yet polished and pointed, essayistic elegance.";
                        NumberOfPages += 50;
                        return false;
                    }

                    else if (answer == 2)
                    {
                        Console.WriteLine("You are now reading Fiction...");
                        Description = "Consisting of people, events, or places that are imaginary.";
                        NumberOfPages += 70;
                        return false;
                    }

                    else if (answer == 3)
                    {
                        Console.WriteLine("You are now reading Professional Literature...");
                        Description = "Designed to strengthen instructional decision making.";
                        NumberOfPages += 65;
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
