using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgiftAnimalShop
{
    class AnimalShop
    {
        private List<Animal> soldAnimals = new List<Animal>();
        private int money;
        public int Money { get => money; set => money = value; }
        public AnimalShop()
        {

        }
        /// <summary>
        /// Takes a string and returns an Animal.
        /// </summary>
        /// <param name="AnimalType"></param>
        /// <returns></returns>
        public Animal SellAnimal(string AnimalType)
        {
            AnimalType = LookForAnimalInString(AnimalType);
            switch (AnimalType)
            {
                case "hund":
                    return new Dog();

                case "fågel":
                    return new Bird();

                case "häst":
                    return new Horse();

                case "orm":
                    return new Snake();

                default:
                    return null;
            }
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
            string soldAnimalsString = "Sålda djur:\n\n";
            foreach (Animal item in soldAnimals)
            {
                soldAnimalsString += item.GetInfo() +"\n";
            }
            soldAnimalsString += $"\nAffärens intjänade pengar: {Money}";
            return soldAnimalsString;
        }
        public string LookForAnimalInString(string AnimalType)
        {
            string[] availableAnimals = { "hund", "häst", "fågel", "orm" };
            AnimalType = AnimalType.ToLower();
            foreach (string item in availableAnimals)
            {
                if (AnimalType.Contains(item)) AnimalType = item;
            }
            return AnimalType;
        }
    }
}
