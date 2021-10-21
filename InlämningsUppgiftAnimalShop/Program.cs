using System;
using System.Threading;

namespace InlämningsUppgiftAnimalShop
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateScreen();
            AnimalShop myShop = new AnimalShop();            
            SalesManSpeech($"Välkommen till min affär!");
            Console.WriteLine($"{AnimalsForSale()}");
            SalesManSpeech("Vill du köpa något av dessa djur?");
            Console.WriteLine("(Ja / Nej)\n");
            if (YesOrNo(Console.ReadLine()))
            {
                do
                {
                    UpdateScreen();
                    Shop(ref myShop);
                    SalesManSpeech("Vill du handla vidare?");
                } while (YesOrNo(Console.ReadLine()));
                UpdateScreen();
                SalesManSpeech("Tack och välkommen åter!");
                Thread.Sleep(500);
                UpdateScreen();                
                Console.WriteLine(myShop.Summary());
            }
            else
            {
                SalesManSpeech("\nOkej, välkommen åter när du vill handla!");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Handles the interaction between salesman and customer when buying a animal.
        /// </summary>
        /// <param name="myShop"></param>
        static void Shop(ref AnimalShop myShop)
        {
            Console.WriteLine($"{AnimalsForSale()}");
            SalesManSpeech("Vilken typ av djur vill du köpa?");
            string userInput = Console.ReadLine();
            Animal displayAnimal = myShop.SellAnimal(userInput);
            while (displayAnimal == null)
            {
                UpdateScreen();
                SalesManSpeech($"Vi har tyvärr ingen {userInput}.");
                Console.WriteLine(AnimalsForSale());
                SalesManSpeech("Vilken typ av djur vill du köpa?");
                userInput = Console.ReadLine();
                displayAnimal = myShop.SellAnimal(userInput);
            }
            bool loopBreaker = false;
            do
            {
                string _userInput;
                UpdateScreen();
                Console.WriteLine($"*hämtar {displayAnimal.AnimalType}*\n");
                SalesManSpeech($"Vi har följande {displayAnimal.AnimalType} till salu:");
                Console.WriteLine($"{displayAnimal.GetInfo()}");
                SalesManSpeech($"Vill du köpa {displayAnimal.Name} för {displayAnimal.Prize} kronor?");
                _userInput = Console.ReadLine();
                if (_userInput == "pruta")
                {
                    Random randomizer = new Random();
                    decimal discount = randomizer.Next(7, 10);
                    discount /= 10;
                    displayAnimal.Prize = Convert.ToInt32(displayAnimal.Prize * discount);
                    Console.WriteLine("\n*föreståndaren kommer närmare och viskar*");
                    SalesManSpeech($"Okej, vad sägs om att köpa {displayAnimal.Name} för {displayAnimal.Prize} kronor?");
                    _userInput = Console.ReadLine();
                }
                if (YesOrNo(_userInput))
                {
                    myShop.AddSoldAnimal(displayAnimal);
                    SalesManSpeech($"\nTack för en bra affär!");
                    break;
                }
                else
                {
                    SalesManSpeech($"\nVill du titta på en annan {displayAnimal.AnimalType}?");
                    if (YesOrNo(Console.ReadLine()))
                    {
                        displayAnimal = myShop.SellAnimal(userInput);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine();
                        loopBreaker = true;
                    }
                }
            } while (!loopBreaker);
            
        }
        static string AnimalsForSale()
        {
            return "Dessa djur har vi till salu:\nHund\nHäst\nFågel\nOrm\n";
        }
        /// <summary>
        /// Tries to determine whether the user means yes or no. Returns yes if unsure.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        static bool YesOrNo(string userInput)
        {
            string[] noWords = { "nej", "nopp", "ne", "inte", "icke", "njet", "no", "nix", "nja", "nej tack", "nej tack!" , "nej!" };
            userInput = userInput.Trim().ToLower();
            if (userInput == "n") return false;
            foreach (string item in noWords)
            {
                if (userInput == item) return false;
            }
            return true;
        }
        /// <summary>
        /// Writes the speech of the salesman slowly.
        /// </summary>
        /// <param name="input"></param>
        static void SalesManSpeech(string input)
        {
            foreach (char item in input)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
            Console.WriteLine("\n");
        }
        /// <summary>
        /// Draws the "background"
        /// </summary>
        static void UpdateScreen()
        {
            Console.Clear();
            Console.WriteLine("DJURAFFÄREN\n");
        }
    }
}
