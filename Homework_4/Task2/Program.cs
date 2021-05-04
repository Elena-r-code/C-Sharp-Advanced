using Entities2;
using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericsDB<Pet>.PetStore.Add(new Dog("Max", "Retriever", 5, "Bread"));

            GenericsDB<Pet>.PetStore.Add(new Dog("Boomer", "Poodle", 4, "Meat"));

            GenericsDB<Pet>.PetStore.Add(new Cat("Teddy", "Siamese", 3, true, 7));

            GenericsDB<Pet>.PetStore.Add(new Cat("Emma", "Calico", 3, true, 4));

            GenericsDB<Pet>.PetStore.Add(new Fish("Tony", "Tuna", 3, "blue", 17));

            GenericsDB<Pet>.PetStore.Add(new Fish("Jonny", "Blobfish", 3, "white", 25));

            Console.WriteLine("AVAILABLE PETS:\n");
            GenericsDB<Pet>.PrintPets();
        

            GenericsDB<Pet>.BuyPet(GenericsDB<Pet>.PetStore[0]);
            GenericsDB<Pet>.BuyPet(GenericsDB<Pet>.PetStore[3]);

            Console.WriteLine("\nAVEILABLE PETS AFTER YOUR SHOPPING: \n");
            GenericsDB<Pet>.PrintPets();

            Console.ReadLine();
        }
    }
}
