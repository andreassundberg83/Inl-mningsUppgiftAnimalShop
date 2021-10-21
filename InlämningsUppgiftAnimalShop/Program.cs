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
            SalesManSpeech("Vilket djur vill du köpa?");
            string userInput = Console.ReadLine();
            Animal displayAnimal = myShop.SellAnimal(userInput);
            while (displayAnimal == null)
            {
                SalesManSpeech($"Vi har tyvärr ingen {userInput}.");
                Console.WriteLine(AnimalsForSale());
                displayAnimal = myShop.SellAnimal(Console.ReadLine());
            }
            bool loopBreaker = false;
            do
            {
                UpdateScreen();
                SalesManSpeech($"Vi har följande {displayAnimal.AnimalType} till salu:");
                Console.WriteLine($"{displayAnimal.GetInfo()}");
                SalesManSpeech($"Vill du köpa {displayAnimal.Name} för {displayAnimal.Prize}");
                if (YesOrNo(Console.ReadLine()))
                {
                    myShop.AddSoldAnimal(displayAnimal);
                    SalesManSpeech($"\nTack så mycket!");
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
            string[] noWords = { "nej", "nopp", "ne", "inte", "icke", "njet", "no", "nix", "nja" };
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
                Thread.Sleep(20);
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
