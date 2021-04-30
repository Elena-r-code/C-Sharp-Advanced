using Homework.Classes;
using System;
using System.Collections.Generic;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog firstDog = new Dog("Buddy", "brown", 5, "bulldog", "blue");
            Dog secondDog = new Dog("Milo", "white", 3, "briard", "brown");
            Dog thirdDog = new Dog("Blazzy", "black", 6, "boxer", "green");

            Cat firstCat = new Cat("Bella", "white", 2, true);
            Cat secondCat = new Cat("Kitty", "orange", 7, true);
            Cat thirdCat = new Cat("Garfield", "brown", 5, false);

            firstDog.PrintAnimal();
            secondDog.Bark();
            thirdCat.Eat("fish");

            List<Animal> animals = new List<Animal>
            {
                firstDog,
                secondDog,
                thirdDog,
                secondCat,
                thirdCat
            };

            try
            {
                if (animals != null)
                {
                    foreach (Animal animal in animals)
                    {
                        if (animal.GetType() == firstDog.GetType())
                        {
                            ((Dog)animal).Bark();
                        }

                        else if (animal.GetType() == firstCat.GetType())
                        {
                            ((Cat)animal).Eat("bread");
                        }
                        else
                        {
                            throw new Exception("NO CATS AND DOGS!!!!!!!!!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
