using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgiftAnimalShop
{
    class Animal
    {
        // If you dont want data to be accessed outside the class, you should make it private. 
        // You can make it available by using encapsulation.

        // It is usefull to have multiple constructors when you want to be able to use different types or amounts of parameters.

        //I dont want these fields to be accessed outside the class, so they are private.
        private string[] maleNames = {"Charlie", "Ludde", "Sigge", "Bamse", "Bosse", "Rocky", "Max", "Tyson", "Jack", "Gizmo", "Loke", "Buster", "Zorro"};
        private string[] femaleNames = { "Molly", "Bella", "Doris", "Sally", "Stella", "Ronja", "Daisy", "Zelda", "Lady", "Tyra", "Fanny", "Smulan", "Fia" };
        private string[] colors = {"Brun", "Svart", "Vit", "Grå", "Röd", "Gul", "Blå", "Lila"};
        private int age;
        private bool gender;        
        private string color;
        private string name;
        private int prize;
        private string animalType;

        //So I made these public properties to be able to access them. Encapsulation.
        public string Age 
        { 
            get 
            {
                if (age < 12)
                {
                    return $"{age} månader";
                }
                else if (age > 12 && age < 24)
                {
                    return $"{age / 12} år och {age - 12} månader";
                }
                else
                {
                    return $"{age / 12} år";  
                }
            } 
        }
        public string Gender 
        { 
            get 
            {
                if (gender == true)
                {
                    return "Hona";
                }
                else
                {
                    return "Hane";
                }
            }
        }
        public string Color { get => color; set => color = value; }
        public string Name { get => name; set => name = value; }
        public int Prize { get => prize; set => prize = value; }
        public string AnimalType { get => animalType; set => animalType = value; }
        public Animal(int prize, byte colorMaxValue, int maxAge, string animalType)
        {
            Random randomizer = new Random();
            age = randomizer.Next(4, maxAge);
            gender = randomizer.Next(2) == 0;

            //Gives discount for older animals
            if (age >= maxAge*0.6 && age < maxAge*0.8)
            {
                this.Prize = Convert.ToInt32(prize * 0.6);
            }
            else if (age >= maxAge * 0.8)
            {
                this.Prize = Convert.ToInt32(prize * 0.3);
            }
            else
            {
                this.Prize = prize;
            }

            if (gender)
            {
                this.Name = femaleNames[randomizer.Next(13)];
            }
            else
            {
                this.Name = maleNames[randomizer.Next(13)];
            }
            if (colorMaxValue != 0)
            {
                this.Color = colors[randomizer.Next(colorMaxValue)];
            }
            this.AnimalType = animalType;
            

        }
        /// <summary>
        /// Returns info about the specific animal in a string.
        /// </summary>
        /// <returns></returns>
        public virtual string GetInfo() 
        {
            return "Hej";
        }
        
    }
}
