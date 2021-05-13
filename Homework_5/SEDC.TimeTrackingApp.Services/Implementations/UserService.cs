using SEDC.TimeTrackingApp.Domain.Database;
using SEDC.TimeTrackingApp.Domain.Interfaces;
using SEDC.TimeTrackingApp.Domain.Models;
using SEDC.TimeTrackingApp.Services.Helpers;
using SEDC.TimeTrackingApp.Services.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using TimeTrackingApp.Domain.Models;

namespace SEDC.TimeTrackingApp.Services.Implementations
{
    public class UserService<T> : IUserService<T> where T : User
    {
        public Reading reading;
        public Exercising exercising;
        public Working working;
        public Other otherHobbies;
        private IDataBase<T> _database;
        public UserService()
        {
            reading = new Reading();
            exercising = new Exercising();
            working = new Working();
            otherHobbies = new Other();
            _database = new Database<T>();
        }

        public void AddUser(T user)
        {
            _database.Insert(user);

        }

        //public T ChangeFirstLastName(T user)
        //{
        //    throw new NotImplementedException();
        //}

        //public T ChangePassword()
        //{
        //    throw new NotImplementedException();
        //}

        //public T DeactivateAccount(T user)
        //{
        //    throw new NotImplementedException();
        //}

        public int LogIn()
        {
            User user = null;
            int i = 4;
            while (i > 0)
            {
                Console.Clear();
                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password :");
                string password = Console.ReadLine();
                user = _database.CheckUser(username, password);
                if (user != null)
                {
                    while (true)
                    {
                        Console.Clear();
                        user.GetInfo();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("               MAIN MENU :");
                        Console.WriteLine(" 1) Track \n 2) Change password \n 3) Change first and last name \n 5) Deactivate account \n 4) Log out ");
                        bool success = int.TryParse(Console.ReadLine(), out int menuChoice);
                        if (success)
                        {
                            if (menuChoice == 1)
                            {
                                Track((T)user);
                            }
                            else if (menuChoice == 4)
                            {
                                LogOut();
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
                    Console.WriteLine("Wrong input! Try again!");
                }
            }
            return 1;


        }

        public int LogOut()
        {
            Console.Clear();
            Thread.Sleep(2000);
            Console.WriteLine("Logging you out...");
            Console.WriteLine("Press anything to continue...");
            Console.ReadKey();
            return 1;
        }

        public bool Register()
        {
            while (true)
            {
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
                User newRegisteredUser = new User(firstName, lastName, age, username, password);
                if (ValidationHelper.UsernameValidation(newRegisteredUser) && ValidationHelper.PasswordValidation(newRegisteredUser) && ValidationHelper.FirstLastNameValidation(newRegisteredUser) && ValidationHelper.ValidateAge(newRegisteredUser))
                {
                    _database.Insert((T)newRegisteredUser);
                    return false;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong! Please check that you entered your information correct!");
                    Console.WriteLine(ValidationHelper.UsernameValidation(newRegisteredUser));
                    Console.WriteLine(ValidationHelper.PasswordValidation(newRegisteredUser));
                    Console.WriteLine(ValidationHelper.FirstLastNameValidation(newRegisteredUser));
                    Console.WriteLine(ValidationHelper.ValidateAge(newRegisteredUser));
                    Console.WriteLine("Press anything to continue.");
                    Console.ReadKey();
                }
            }
        }

        public void Track(T user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your activity :");
                Console.WriteLine("1)Reading \n2)Ecercising \n3)Working\n4)Other");
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

                    }
                }

                else if (choice == 3)
                {
                    working.WorkingActive();
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
                        Console.WriteLine($"Time spent working : {Math.Round(timeInSeconds / 60, 2)} minutes");
                        Console.WriteLine("Press anything to continue...");
                        Console.ReadKey();

                    }
                }

                else if (choice == 4)
                {
                    otherHobbies.OtheHobbiesActive();
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
                        Console.WriteLine($"Time spent doing your hobby: {Math.Round(timeInSeconds / 60, 2)} minutes");
                        Console.WriteLine("Press anything to continue...");
                        Console.ReadKey();

                    }
                }
            }
        }


    }
}
