using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgiftAnimalShop
{
    class Dog : Animal
    {
        private const int MAX_AGE = 192;
        private string[] races = { "Schäfer", "Bulldog", "Dobermann", "Pudel", "Australian Shepard"};
        private byte size;
        private string race;
        private bool watchDog;
        private bool shepard;
        public string Size 
        { 
            get 
            {
                switch (size)
                {
                    case 0:
                        return "Liten";
                    case 1:
                        return "Medium";
                    case 2:
                        return "Stor";
                    default:
                        return "";
                        
                }
            } 
        }
        public string Race { get => race; set => race = value; }
        public string WatchDog { get {if (watchDog) return "Vakthund"; else return "Ej vakthund";} }
        public string Shepard { get {if (shepard) return "Vallhund"; else return "Ej vallhund";} }
        public Dog() : base(12000, 4, MAX_AGE, "hund")
        {
            Random randomizer = new Random();
            this.Race = races[randomizer.Next(5)];
            switch (race)
            {
                case "Schäfer":
                    watchDog = true;
                    shepard = true;
                    break;
                case "Bulldog":
                    watchDog = false;
                    shepard = false;
                    break;
                case "Dobermann":
                    watchDog = true;
                    shepard = false;
                    break;
                case "Pudel":
                    watchDog = false;
                    shepard = false;
                    break;
                case "Australian Shepard":
                    watchDog = true;
                    shepard = true;
                    break;
            }
            this.size = Convert.ToByte(randomizer.Next(3));
        }
        public override string GetInfo()
        {
            string areaOfUse;
            if (shepard == false && watchDog == false)
            {
                areaOfUse = "Sällskap";
            }
            else
            {
                areaOfUse = $"{Shepard} , {WatchDog}";
            }
            return $"{Name}, {Gender}, {Age}" +
                $"\n{Color} {Size.ToLower()} {Race}.\n" +
                $"Användningsområde: {areaOfUse}\n" +
                $"Pris: {Prize} kr\n";
               
        }
    }
}
