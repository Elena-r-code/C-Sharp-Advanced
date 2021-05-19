using SEDC.TimeTrackingApp.Domain.Enums;
using SEDC.TimeTrackingApp.Services.Implementations;
using SEDC.TimeTrackingApp.Services.Interfaces;
using System;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.App
{
    class Program
    {
        public static IUserService<User> _serviceUser = new UserService<User>();
        public static void Menu()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("             WELCOME TO TIME TRACKING APP !\n");
            Console.WriteLine("\n                      MENU:\n");
            Console.WriteLine(" 1) LOG IN\n 2) REGISTER \n 3) EXIT");
            while (true)
            {
                bool success = int.TryParse(Console.ReadLine(), out int menuChoice);
                if (!success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input! Try again with choosing one of the options in the menu as number!");
                    Console.ResetColor();
                }
                else if (menuChoice == 1)
                {
                    _serviceUser.LogIn();

                }
                else if (menuChoice == 2)
                {
                    _serviceUser.Register();
                    Console.ReadKey();
                    Menu();
                    
                }
                else if (menuChoice == 3)
                {
                    break;
                }

            }

        }


        static void Main(string[] args)
        {
            _serviceUser.AddUser(new User("Elena", "Betinska", 22, "Elena11", "Elena11", Activities.Exercising));
            _serviceUser.AddUser(new User("Marija", "Mladenovksa", 22, "Marija11", "Marija11", Activities.Reading));
            _serviceUser.AddUser(new User("Ana", "Stojkova", 25, "Ana11", "Ana11", Activities.Working));
            _serviceUser.AddUser(new User("Mila", "Velkovksa", 24, "Mila11", "Mila11", Activities.Other));
            _serviceUser.AddUser(new User("Aleksandar", "Shit", 26, "Aco123", "Shit123", Activities.Other));

            Menu();
        }
    }
}
