using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgiftAnimalShop
{
    class AnimalShop
    {
        // Added listForShowingAvailabelAnimals at the end of development, just cause I thought it would make it easier to add another class. It  will
        // automatically show in Program.AnimalsForSale(). Before I had them "hard-coded". That is also why the method AnimalsForSale() is in
        // the program class.
        public List<Animal> listForShowingAvailableAnimals = new List<Animal>();
        private List<Animal> soldAnimals = new List<Animal>();
        private int money;
        public int Money { get => money; set => money = value; }
        public AnimalShop()
        {
            listForShowingAvailableAnimals.Add(SellAnimal("hund"));
            listForShowingAvailableAnimals.Add(SellAnimal("häst"));
            listForShowingAvailableAnimals.Add(SellAnimal("fågel"));
            listForShowingAvailableAnimals.Add(SellAnimal("orm"));

        }
        /// <summary>
        /// Takes a string and returns an Animal.
        /// </summary>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public Animal SellAnimal(string animalType)
        {
            animalType = LookForAnimalInString(animalType);
            return animalType switch
            {
                "hund" => new Dog(),
                "fågel" => new Bird(),
                "häst" => new Horse(),
                "orm" => new Snake(),
                _ => null,
            };
        }
        /// <summary>
        /// Adds the sold animal to the shops List<> of sold animals.
        /// </summary>
        /// <param name="soldAnimal"></param>
        public void AddSoldAnimal(Animal soldAnimal)
        {
            soldAnimals.Add(soldAnimal);
            Money += soldAnimal.Prize;
        }
        /// <summary>
        /// Builds a string of all sold animals.
        /// </summary>
        /// <returns></returns>
        public string Summary()
        {
            string soldAnimalsString = "Sålda djur:\n\n--------------------------------------------\n\n";
            foreach (Animal item in soldAnimals)
            {
                soldAnimalsString += item.GetInfo() + "\n--------------------------------------------\n\n";
                ;
            }
            soldAnimalsString += $"\nAffärens intjänade pengar: {Money}";
            return soldAnimalsString;
        }
        public string LookForAnimalInString(string animalType)
        {
            string[] availableAnimals = { "hund", "häst", "fågel", "orm" };
            animalType = animalType.ToLower();
            foreach (string item in availableAnimals)
            {
                if (animalType.Contains(item)) animalType = item;
            }
            return animalType;
        }
    }
}
