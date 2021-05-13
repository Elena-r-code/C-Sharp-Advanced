using System;
using System.Linq;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Services.Helpers
{

    public static class ValidationHelper
    {
        public static bool UsernameValidation(User user)
        {

            if (user.Username.Length < 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The username must be at least 5 characters long.");
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Username successfully logged !");
                return true;
            }
        }
        public static bool PasswordValidation(User user)
        {
            if (user.Password.Length < 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The password must be at least 6 characters long.");
                return false;
            }
            else
            {
                if (user.Password.Any(char.IsUpper) && user.Password.Any(char.IsDigit))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Password successfully logged.");
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Password must contain at least one capital letter and at least one number.");
                    return false;
                }
            }
        }
        public static bool FirstLastNameValidation(User user)
        {
            if (user.FirstName.Length < 2 && user.LastName.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First and last name can not be shorter than 2 characters.");
                return false;
            }
            else
            {
                if (user.FirstName.Any(char.IsDigit) || user.LastName.Any(char.IsDigit) || user.FirstName.Any(char.IsSymbol) || user.LastName.Any(char.IsSymbol))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("First and last name must not contain numbers or symbols.");
                    return false;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("First and last name successfuly logged !");
                    return true;
                }
            }
        }
        public static bool ValidateAge(User user)
        {
            {
                if (user.Age < 18 || user.Age > 120)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Your age should be between 18 and 120 !");
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Age successfully logged !");
                    return true;
                }

            }

        }
    }
}


