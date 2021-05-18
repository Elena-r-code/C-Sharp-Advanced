using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static string Calculator(int n1, int n2)
        {
            int sum = n1 + n2;
            string result = ($"{n1} + {n2} = {sum}");
            return result;
        }

        static void Main(string[] args)
        {
            string appPath = @"..\..\..\";
            bool folderExerciseExists = Directory.Exists(appPath + "Exercise");

            string folderPath = appPath + "Exercise";

            if (!folderExerciseExists)
            {
                Directory.CreateDirectory(folderPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Exercise folder was created!");
            }

            string filesPath = appPath + "Exercise";
            bool fileCalculationsExists = File.Exists(filesPath);
            if (!fileCalculationsExists)
            {
                File.Create(filesPath + @"\calculations.txt").Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File calculations.txt was created!");

                string calculationFilePath = folderPath + @"\calculations.txt";
                for (int i = 0; i < 3; i++)
                {
                    Console.ResetColor();
                    Console.WriteLine("\n\nEnter number : ");
                    bool isFirstNumNumber = int.TryParse(Console.ReadLine(), out int firstNumber);

                    Console.WriteLine("Enter another number : ");
                    bool isSecondNumNumber = int.TryParse(Console.ReadLine(), out int secondNumber);

                    if (!isFirstNumNumber && !isSecondNumNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter NUMBERS!!!");
                    }
                    else
                    {
                        Console.WriteLine(Calculator(firstNumber, secondNumber));

                        using (StreamWriter sw = new StreamWriter(calculationFilePath, true))
                        {
                            String timeStamp = DateTime.Now.ToString();
                            sw.WriteLine(Calculator(firstNumber, secondNumber));
                            sw.WriteLine(timeStamp);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Result was written in calculations.txt !");
                        }

                    }

                }
            }
            Console.ReadLine();
        }
    }
}
