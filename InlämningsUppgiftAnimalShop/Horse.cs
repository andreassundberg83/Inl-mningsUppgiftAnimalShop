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
        public string Rideable { get { if (rideable) return "Är inriden"; else return "Behöver ridas in"; } }
        public string WildWestSuitable { get { if (wildWestSuitable) return "en perfekt vilda västern-häst!"; else return "olämplig i vilda västern."; } }
        public string AfraidOfGunfire { get { if (afraidOfGunfire) return "Ja"; else return "Nej"; } }
        public string Speed 
        {
            get 
            {
                switch (speed)
                {
                    case 0:
                        return "Extremt långsam";
                    case 1:
                        return "Väldigt långsam";
                    case 2:
                        return "Långsam";
                    case 3:
                        return "Ganska långsam";
                    case 4:
                        return "Lagom";
                    case 5:
                        return "Ganska snabb";
                    case 6:
                        return "Snabb";
                    case 7:
                        return "Väldigt snabb";
                    case 8:
                        return "Extremt snabb";
                    default:
                        return "Lagom";
                }
            }
        }
        public Horse() : base(20000, 4, MAX_AGE, "häst")
        {
            Random randmomizer = new Random();
            speed = Convert.ToByte(randmomizer.Next(9));
            afraidOfGunfire = randmomizer.Next(2) == 0;
            rideable = randmomizer.Next(2) == 0;
            if (rideable && !afraidOfGunfire && speed >= 5) wildWestSuitable = true; else wildWestSuitable = false;
            GetHorsePrize(rideable, afraidOfGunfire, speed);
        }
        public override string GetInfo()
        {
            string studOrNot = "";
            if (Gender == "Hona") studOrNot = "Sto"; else studOrNot = "Hingst";

            return $"{Name}, {studOrNot}, {Age}\n" +
                $"{Rideable}.\n" +
                $"Färg: {Color} \n" +
                $"Skotträdd: {AfraidOfGunfire}\n" +
                $"Snabbhet: {Speed}\n" +
                $"{Gender.Substring(0,3)} är {WildWestSuitable}\n" +
                $"Pris: {Prize} kr\n";
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
