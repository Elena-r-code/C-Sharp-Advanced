using System;
using System.Collections.Generic;
using System.IO;

namespace Bonus
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person() {FirstName = "Elena", LastName ="Betinska", Age=21},
                new Person() {FirstName = "Aleksandar", LastName ="Ivanovski", Age=26},
                new Person() {FirstName = "Mila", LastName ="Velkovska", Age=22},
                new Person() {FirstName = "Viktor", LastName ="Stojkov", Age=27},
                new Person() {FirstName = "Marija", LastName ="Mladenovksa", Age=21},
             };

            string appPath = @"..\..\..\";
            bool fileExists = File.Exists(appPath + @"newFile.txt");

            if (!fileExists)
            {
                File.Create(appPath + @"/newFile.txt").Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File created!");
                Console.ResetColor();

                string filePath = appPath + @"newFile.txt";
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    foreach (Person person in people)
                    {
                        sw.WriteLine(person.PrintInfo());

                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThe list of people are written in the file!\n");
                    Console.ResetColor();
                }

                using (StreamReader sr = new StreamReader(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nReading the NEW list of people from the file: \n");
                    Console.ResetColor();

                    List<Person> newList = new List<Person>();

                    foreach (Person person in people)
                    {
                        string line = sr.ReadLine();
                        //Console.WriteLine(line);
                        string[] name = line.Split(" ");
                        bool AgeToInt = int.TryParse(name[2], out int age);
                        if (AgeToInt)
                        {
                            newList.Add(new Person() { FirstName = name[0], LastName = name[1], Age = age });
                        }

                    }
                    for (int i = 0; i < newList.Count; i++)
                    {
                        Console.WriteLine(newList[i].PrintInfo());
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
