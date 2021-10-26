using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgiftAnimalShop
{
    class Horse : Animal
    {
        private const int MAX_AGE = 300;
        private bool rideable;
        private bool afraidOfGunfire;
        private byte speed;
        private bool wildWestSuitable;
        public string Rideable { get { return rideable ? "Är inriden" : "Behöver ridas in"; } }
        public string WildWestSuitable { get { return wildWestSuitable ? "en perfekt vilda västern-häst!" : "olämplig i vilda västern."; } }
        public string AfraidOfGunfire { get { return afraidOfGunfire ? "Ja" : "Nej"; } }
        public string Speed 
        {
            get 
            {
                return speed switch
                {
                    0 => "Extremt långsam",
                    1 => "Väldigt långsam",
                    2 => "Långsam",
                    3 => "Ganska långsam",
                    4 => "Lagom",
                    5 => "Ganska snabb",
                    6 => "Snabb",
                    7 => "Väldigt snabb",
                    8 => "Extremt snabb",
                    _ => "Lagom",
                };
            }
        }
        public Horse() : base(20000, 4, MAX_AGE, "häst")
        {
            Random randmomizer = new Random();
            speed = Convert.ToByte(randmomizer.Next(9));
            afraidOfGunfire = randmomizer.Next(2) == 0;
            rideable = randmomizer.Next(2) == 0;
            wildWestSuitable = rideable && !afraidOfGunfire && speed >= 5;
            GetHorsePrize(rideable, afraidOfGunfire, speed);
        }
        public override string GetInfo()
        {
            string studOrNot = Gender == "Hona" ? "Sto" : "Hingst";
            return $"{Name}, {studOrNot}, {Age}\n" +
                $"{Rideable}.\n" +
                $"Färg: {Color} \n" +
                $"Skotträdd: {AfraidOfGunfire}\n" +
                $"Snabbhet: {Speed}\n" +
                $"{Gender.Substring(0,3)} är {WildWestSuitable}\n" +
                $"Pris: {string.Format("{0:C}", Prize)}\n";
        }
        /// <summary>
        /// Calculates the prize for a horse from the parameters.
        /// </summary>
        /// <param name="rideable"></param>
        /// <param name="afraidOfGunfire"></param>
        /// <param name="speed"></param>
        private void GetHorsePrize(bool rideable, bool afraidOfGunfire, byte speed)
        {
            Prize = (Prize * (100 + (speed * 3))) / 100;
            if (rideable)
            {
                Prize = (Prize * (110)) / 100;
            }
            if (afraidOfGunfire)
            {
                Prize = (Prize / 110) * 100;
            }
        }
    }
}
