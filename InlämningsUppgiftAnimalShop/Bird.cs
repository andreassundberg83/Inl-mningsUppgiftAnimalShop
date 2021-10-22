using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgiftAnimalShop
{
    class Bird : Animal 
    {
        private const int MAX_AGE = 192;
        private bool talks;
        private bool birdOfPrey;
        private bool migrates;
        public string Talks { get { return talks ? "talande " : ""; } }
        public string BirdOfPrey { get { return birdOfPrey ? "rovfågel" : "frö- och insektsätande fågel"; } }
        public string Migrates { get { return migrates ? "Ja" : "Nej"; } }
        public Bird() : base(2000, 8, MAX_AGE, "fågel")
        {
            Random randomizer = new Random();
            talks = randomizer.Next(2) == 0;
            birdOfPrey = randomizer.Next(2) == 0;
            migrates = randomizer.Next(2) == 0;
        }
        public override string GetInfo()
        {
            return $"{Name}, {Gender}, {Age}" +
                $"\n{Color} {Talks}{BirdOfPrey}.\n" +
                $"Flyttfågel: {Migrates}\n" +
                $"Pris: {Prize} kr\n";
        }
    }
}
