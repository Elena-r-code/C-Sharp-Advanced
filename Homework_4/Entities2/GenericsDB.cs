using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities2
{
    public static class GenericsDB<T> where T : Pet
    {
        public static List<T> PetStore { get; set; }
        static GenericsDB()
        {
            PetStore = new List<T>();
        }
        public static void PrintPets()
        {
            foreach (T pet in PetStore)
            {
                Console.WriteLine(pet.Name);
            }
        }

        public static void BuyPet(T pet)
        {
            T existingPet = PetStore.FirstOrDefault(x => x.Name == pet.Name);
            if (existingPet == null)
            {
                Console.WriteLine($"Sorry, we don't have this pet !");
            }
            else
            {
                PetStore.Remove(pet);
                Console.WriteLine($"\nCongratulations! You bought this pet: : {pet.Name} !");
            }
        }

    }
}
