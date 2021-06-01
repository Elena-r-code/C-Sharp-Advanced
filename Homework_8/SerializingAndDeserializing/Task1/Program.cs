using System;
using Task1.Domain;

namespace Task1
{
    class Program
    {
        public static DataBase _database = new DataBase();

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please enter the following information for the dog :\n");
            Console.WriteLine("Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("\nAge : ");
            bool success = int.TryParse(Console.ReadLine(), out int age);
            if (!success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n     Please enter a number!!!");
                return;
            }
            else
            {
                Console.WriteLine("\nColor : ");
                string color = Console.ReadLine();

                Dog dog = new Dog(name, age, color);
                _database.Insert(dog);
                Console.WriteLine("This dog is now added in the list! Check the file! :)");
            }
           
        }

        static void Repeat()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(" \n\n\n\n\n\n                   HELLO ! CHOOSE OPTION : \n\n\n\n\n\n            1. Add dog to the list \n\n            2. See the whole list");
                bool success1 = int.TryParse(Console.ReadLine(), out int answer);
                if (!success1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!  Plese choose one of the available options!");
                }
                else if(answer == 1)
                {
                    Console.Clear();
                    Menu();
                    Console.WriteLine("Press anything to continue...");
                    Console.ReadKey();
                    break;
                }
                else if(answer == 2)
                {
                    Console.Clear();
                    _database.GetAll();
                    Console.WriteLine("Press anything to continue...");
                    Console.ReadKey();
                    break;
                }

            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Repeat();
                Console.ReadKey();
            }
            Console.ReadLine();
        }
    }
}
