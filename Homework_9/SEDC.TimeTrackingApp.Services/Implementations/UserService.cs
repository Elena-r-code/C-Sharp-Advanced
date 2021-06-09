using SEDC.TimeTrackingApp.Domain.Database;
using SEDC.TimeTrackingApp.Domain.Enums;
using SEDC.TimeTrackingApp.Domain.Interfaces;
using SEDC.TimeTrackingApp.Domain.Models;
using SEDC.TimeTrackingApp.Services.Helpers;
using SEDC.TimeTrackingApp.Services.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using TimeTrackingApp.Domain.Database;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Services.Implementations
{
    public class UserService<T> : IUserService<T> where T : User
    {
        public Reading reading;
        public Domain.Models.Exercising exercising;
        public Working working;
        public Other otherHobbies;
        private IDataBase<T> _database;

        public UserService()
        {
            reading = new Reading();
            exercising = new Domain.Models.Exercising();
            working = new Working();
            otherHobbies = new Other();
            _database = new FileDatabase<T>();
        }

        public void AddUser(T user)
        {
            _database.Insert(user);

        }



        public T ChangePassword(T user)
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Enter your new password:");
                string newPassword = Console.ReadLine();
                user.Password = newPassword;
                if (ValidationHelper.PasswordValidation(user) == true)
                {
                    flag = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You changed your password! Now log in: ");
                    Thread.Sleep(2000);
                    LogIn();
                    return user;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Password you entered is not strong enough!");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                }
            }
            return null;
        }

        public T ChangeFirstName(T user)
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Enter new first name:");
                string newFirstName = Console.ReadLine();

                user.FirstName = newFirstName;

                if (ValidationHelper.FirstLastNameValidation(user) == true)
                {
                    flag = false;
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You changed your first name! Now log in: ");
                    Thread.Sleep(2000);
                    LogIn();
                    return user;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong! Press any key to try again.");
                    LogIn();
                    Console.ReadKey();
                }
            }
            return null;
        }

        public T ChangeLastName(T user)
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Enter new last name:");
                string newLastName = Console.ReadLine();

                user.LastName = newLastName;

                if (ValidationHelper.FirstLastNameValidation(user) == true)
                {
                    flag = false;
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You changed your last name! Now log in: ");
                    Thread.Sleep(2000);
                    LogIn();
                    return user;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong! Press any key to try again.");
                    LogIn();
                    Console.ReadKey();
                }
            }
            return null;
        }

        public T DeactivateAccount(T userInput)
        {
            User user = null;
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                user = _database.RemoveUser(userInput);
                if (user == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User does not exits");
                    Console.WriteLine("Press any key to continue");
                    LogIn();
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User account succesfully deactivated!");
                    user.AccountActive = false;
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    LogIn();
                    flag = false;
                    return (T)user;
                }
            }
            return (T)user;
        }



        public int LogIn()
        {
            User user = null;
            int i = 4;
            while (i > 0)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password :");
                string password = Console.ReadLine();
                user = _database.CheckUser(username, password);
                if (user != null)
                {
                    bool menuFlag = true;
                    while (menuFlag)
                    {
                        if (user.AccountActive == false)    
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Your acc was deactivated, do you like to activate it again ?");
                            Console.WriteLine("1. Yes \n2. No");
                            bool activate = int.TryParse(Console.ReadLine(), out int activateAcc); 
                            if (activate) 
                            { 
                                if (activateAcc == 1) 
                                { 
                                    _database.ActivateAccount(user); 
                                } 
                                else if (activateAcc == 2) 
                                { 
                                    break; 
                                } 
                            } 
                        } 

                        Console.Clear();
                        Console.ResetColor();
                        user.GetInfo();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("               MAIN MENU :");
                        Console.WriteLine(" 1) Track \n 2) Account Management \n 3) Log out  \n 4) Statistics");
                        bool success = int.TryParse(Console.ReadLine(), out int menuChoice);
                        if (success)
                        {
                            if (menuChoice == 1)
                            {
                                Track((T)user);
                                menuFlag = true;
                            }
                            else if (menuChoice == 2)
                            {


                                Console.WriteLine("Choose option :  \n 1) Change password  \n 2) Change first name \n 3) Change last name \n 4) Deactivate account \n 5) Back to main menu");
                                bool ValidationAccMan = int.TryParse(Console.ReadLine(), out int option);
                                if (ValidationAccMan)
                                {
                                    if (option == 1)
                                    {
                                        _database.Update(ChangePassword((T)user));
                                        menuFlag = false;
                                        return 1;
                                    }
                                    else if (option == 2)
                                    {
                                        _database.Update(ChangeFirstName((T)user));
                                        menuFlag = false;
                                        return 2;
                                    }
                                    else if (option == 3)
                                    {
                                        _database.Update(ChangeLastName((T)user));
                                        menuFlag = false;
                                        return 3;
                                    }
                                    else if (option == 4)
                                    {
                                        DeactivateAccount((T)user);
                                        menuFlag = false;
                                        return 4;
                                    }
                                    else if(option == 5)
                                    {
                                        menuChoice = 1;
                                    }
                                }

                            }
                            else if (menuChoice == 3)
                            {
                                LogOut();
                                menuFlag = false;
                                return 9;
                            }
                            else if (menuChoice == 4)
                            {
                                Statistics((T)user);
                                menuFlag = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input! Try again!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong input! Try again!");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect username or password!");
                    Console.WriteLine($"Press any key to enter login information again! \n You have {i - 1} attempts left");
                    if (i == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You used all your attempts! Sorry!");
                    }
                    Console.ReadKey();
                }
                i--;
            }
            return 0;


        }

        public int LogOut()
        {
            Console.ResetColor();
            Console.Clear();
            Thread.Sleep(2000);
            Console.WriteLine("Logging you out...");
            Console.WriteLine("Press anything to continue...");
            Console.ReadKey();
            return 9;
        }

        public void Register()
        {
            bool flag = true;
            while (flag)
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("To create account, please enter the following information: ");
                Console.WriteLine("First Name :");
                string firstName = Console.ReadLine();
                Console.WriteLine("Last Name :");
                string lastName = Console.ReadLine();
                Console.WriteLine("Username : ");
                string username = Console.ReadLine();
                Console.WriteLine("Password : ");
                string password = Console.ReadLine();
                Console.WriteLine("Your age :");
                bool isAgeNumber = int.TryParse(Console.ReadLine(), out int age);

                User newRegisteredUser = new User(firstName, lastName, age, username, password, Activities.Other);
                if (ValidationHelper.UsernameValidation(newRegisteredUser) && ValidationHelper.PasswordValidation(newRegisteredUser) && ValidationHelper.FirstLastNameValidation(newRegisteredUser) && ValidationHelper.ValidateAge(newRegisteredUser))
                {
                    _database.Insert((T)newRegisteredUser);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nYour registration was successful!");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nNow log in : ");
                    Thread.Sleep(2000);
                    LogIn();
                    flag = false;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong! Please check that you entered your information correct!");
                    Console.WriteLine(ValidationHelper.UsernameValidation(newRegisteredUser));
                    Console.WriteLine(ValidationHelper.PasswordValidation(newRegisteredUser));
                    Console.WriteLine(ValidationHelper.FirstLastNameValidation(newRegisteredUser));
                    Console.WriteLine(ValidationHelper.ValidateAge(newRegisteredUser));
                    Console.ResetColor();
                    Console.WriteLine("Press anything to continue.");
                    Console.ReadKey();
                }
            }

        }

        public void Track(T user)
        {
            bool flag = true;
            while (flag)
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("Choose your activity :");
                Console.WriteLine("1) Reading \n2) Ecercising \n3) Working\n4) Other\n5) Back to main menu");


                bool success = int.TryParse(Console.ReadLine(), out int choice);
                if (!success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input! Please choose one of the available options!");


                }
                else if (choice == 1)
                {
                    reading.ReadingActive();
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Console.WriteLine("When you are done, and want to stop counting the time, press Enter");
                    string finish = Console.ReadLine();
                    if (finish == "")
                    {
                        stopwatch.Stop();
                        TimeSpan countedTime = stopwatch.Elapsed;
                        double timeInSeconds = Convert.ToDouble(countedTime.TotalSeconds);
                        user.ReadingTime += timeInSeconds / 60;
                        Console.WriteLine($"Time spent reading: {Math.Round(timeInSeconds / 60, 2)} minutes");
                        Console.WriteLine("Press anything to continue...");
                        Console.ReadKey();
                        flag = false;
                    }
                }

                else if (choice == 2)
                {
                    exercising.ExercisingActive();
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Console.WriteLine("When you are done, and want to stop counting the time, press Enter");
                    string finish = Console.ReadLine();
                    if (finish == "")
                    {
                        stopwatch.Stop();
                        TimeSpan countedTime = stopwatch.Elapsed;
                        double timeInSeconds = Convert.ToDouble(countedTime.TotalSeconds);
                        user.ReadingTime += timeInSeconds / 60;
                        Console.WriteLine($"Time spent exercising : {Math.Round(timeInSeconds / 60, 2)} minutes");
                        Console.WriteLine("Press anything to continue...");
                        Console.ReadKey();
                        flag = false;

                    }
                }

                else if (choice == 3)
                {
                    working.WorkingActive(user);
                    flag = false;
                }

                else if (choice == 4)
                {
                    otherHobbies.OtheHobbiesActive(user);
                    flag = false;

                }
                else if(choice == 5)
                {
                    break;
                }
            }
        }
        public void Statistics(T user)
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine($"Statistics for {user.FirstName} {user.LastName}\n Choose option: \n 1) Reading statistics \n 2) Exercising statistics \n 3) Working statistics \n 4) Other hobbies statistics \n 5( Global statistics \n 6)Back to main menu");
            bool success = int.TryParse(Console.ReadLine(), out int choice);
            if (success)
            {
                if (choice == 1)
                {
                    Console.WriteLine($"Reading total time: {Math.Round(user.ReadingTime / 60, 2) } hours.");
                    Console.WriteLine($"Average time of all activities records:{Math.Round((user.ReadingTime + user.ExercisingTime + user.WorkingTime + user.OtherHobbiesTime) / 4, 2)} minutes ");
                    Console.WriteLine($"Total number of pages: {reading.NumberOfPages}");
                    Console.WriteLine($"Favourite activity type: {user.FavouriteType}");
                    Console.WriteLine("Press any key to go to the Main Menu.");
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    Console.WriteLine($"Exercising total time: {Math.Round(user.ExercisingTime / 60, 2)} hours.");
                    Console.WriteLine($"Average time of all activities records:{Math.Round((user.ReadingTime + user.ExercisingTime + user.WorkingTime + user.OtherHobbiesTime) / 4, 2)} minutes ");
                    Console.WriteLine($"Favourite activity type: {user.FavouriteType}");

                    Console.WriteLine("Press any key to go to the Main Menu.");
                    Console.ReadKey();
                }
                else if (choice == 3)
                {
                    Console.WriteLine($"Working total time: {Math.Round(user.WorkingTime / 60, 2)} hours.");
                    Console.WriteLine($"Average time of all activities records:{Math.Round((user.ReadingTime + user.ExercisingTime + user.WorkingTime + user.OtherHobbiesTime) / 4, 2)} minutes ");
                    Console.WriteLine($"Time working at the office : {Math.Round(user.WorkFromHome / 60, 2)} hours. ");
                    Console.WriteLine($"Time working at home : {Math.Round(user.WorkFromOffice / 60, 2)} hours.");
                    Console.WriteLine("Press any key to go to the Main Menu.");
                    Console.ReadKey();
                }
                else if (choice == 4)
                {
                    Console.WriteLine($"Total time for other hobies in hours: {Math.Round(user.OtherHobbiesTime, 2) / 60} hours.");
                    Console.WriteLine("List of all your recorded names of hobies:");
                    foreach (string hobby in user.ListOfHobbies)
                    {
                        Console.WriteLine(hobby);
                    }
                    Console.WriteLine("Press any key to go to the Main Menu.");
                    Console.ReadKey();
                }
                else if (choice == 5)
                {
                    Console.WriteLine($"Global total time of all activities: {Math.Round(user.ReadingTime / 60, 2) + Math.Round(user.ExercisingTime / 60, 2) + Math.Round(user.WorkingTime / 60, 2) + Math.Round(user.OtherHobbiesTime / 60, 2)} hours.\n");
                    Console.WriteLine($"{user.FirstName}'s favourite activity is : {user.FavouriteType}");

                    Console.WriteLine("Press any key to go to the Main Menu.");
                    Console.ReadKey();
                }
                else if(choice == 6)
                {
                    return;
                }
              
            }
            Console.WriteLine("Press any key to go to the Main Menu.");
            Console.ReadKey();           
        }
      
    }
}




