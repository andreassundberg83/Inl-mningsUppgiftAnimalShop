using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgiftAnimalShop
{
    class Snake : Animal 
    {
        private const int MAX_AGE = 192;
        private bool isVenomous;
        private byte length;
        private bool rattles;
        public string IsVenomous { get { return isVenomous ? "giftig " : ""; } }
        public byte Length { get => length; set => length = value; }
        public string Rattles { get { return rattles ? "skaller" : ""; } }
        public Snake() : base(6000, 8, MAX_AGE, "orm")
        {
            Random randomizer = new Random();
            isVenomous = randomizer.Next(2) == 0;
            rattles = randomizer.Next(2) == 0;
            length = Convert.ToByte(randomizer.Next(1,12));
        }
        public override string GetInfo()
        {
            return $"{Name}, {Gender}, {Age}\n" +
                $"{Length} meter lång {IsVenomous}{Rattles}{AnimalType}.\n" +
                $"Pris: {string.Format("{0:C}", Prize)}\n";
        }
    }
}
