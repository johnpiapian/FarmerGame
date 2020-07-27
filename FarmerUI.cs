using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerGame
{
    class FarmerUI
    {
        Farmer f = new Farmer();

        public void GamePlay()
        {
            DisplayWelcome();
            Console.WriteLine("Press enter to start when you are ready.");
            Console.ReadKey();

            string tempMsg = "";
            Boolean exit = false;

            while (!exit)
            {
                DisplayGameState();
                DisplayError(tempMsg);
                tempMsg = "";

                switch (PromptForMove().ToLower())
                {
                    case "chicken":
                        //Console.WriteLine("Move Chicken");
                        f.Move("chicken");
                        break;
                    case "fox":
                        //Console.WriteLine("Move Fox");
                        f.Move("fox");
                        break;
                    case "grain":
                        //Console.WriteLine("Move Grain");
                        f.Move("grain");
                        break;
                    case "":
                        //Console.WriteLine("Move farmer");
                        f.Move("");
                        break;
                    default:
                        //exit = true;
                        tempMsg = "No items found!";
                        break;
                }

                //if statement with win|eat and display accordingly
                //Check if the game is over
                Console.Clear();

                /*if (f.DetermineWin() || f.AnimalAteFood())
                {


                    Console.WriteLine("\n Any key to exit or (Y) to continue..");
                    string keyboard = Console.ReadLine();
                    //Console.ReadKey();
                    if (keyboard.ToUpper() == "Y")
                    {
                        f.resetAll();
                    }
                    else
                    {
                        exit = true;
                    }
                }*/

                if(f.DetermineWin() || f.AnimalAteFood())
                {
                    if (this.AskExit())
                    {
                        exit = true;
                    }else
                    {
                        f.resetAll();
                    }
                }

            }

            DisplayGoodbye();
        }

        //Output
        public void DisplayWelcome()
        {
            string msg = "This is the Farmer Game. The object of the game \nis to get the farmer, fox, chicken, and grain to the otehr side of the river. \nBut hold on, not so fast. If the farmer leaves the chicken and grain on either side of the river alone, \nthe chicken will eat the grain and that is not good. If the farmer leaves the fox and chicken on \nany side of the river alone, the fox will eat the chicken. That is also not good. In either case you lose the game. \nIf you get the farmer, the chicken, the fox, and the grain safely across the river and intact, you win.";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg + "\n\n");
            Console.ResetColor();
        }

        public void DisplayGoodbye()
        {
            Console.WriteLine("\nThank you for playing our game.\n");
        }

        public void DisplayError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n{0}", msg);
            Console.ResetColor();
        }

        public void DisplayGameState()
        {
            Console.Clear();
            Console.WriteLine();
            DisplayNorthBank();
            DisplayRiver();
            DisplaySouthBank();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe Farmer is on the {0} bank of the river", f.TheFarmer);
            Console.ResetColor();
        }

        public void DisplayNorthBank()
        {
            string val = "";
            foreach (string item in f.NorthBank) { val += "<" + item + "> "; }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************North Bank*************************");
            Console.WriteLine(val);
            Console.WriteLine("************************************************************");
            Console.ResetColor();
        }

        public void DisplaySouthBank()
        {
            string val = "";
            foreach (string item in f.SouthBank) { val += "<" + item + "> "; }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("************************************************************");
            Console.WriteLine(val);
            Console.WriteLine("*************************South Bank*************************");
            Console.ResetColor();
        }

        public void DisplayRiver()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("************************************************************");
            Console.WriteLine("************************************************************");
            Console.WriteLine("************************************************************");
            Console.ResetColor();
        }

        // Input
        public string PromptForMove()
        {
            Console.WriteLine("\nChoose next item for the farmer, or just hit enter to cross alone.");
            string input = Console.ReadLine();
            return input;
        }

        public Boolean AskExit()
        {
            Console.WriteLine("\n (Q) to quit or enter to continue...\n");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Q")
            {
                return true;
            }

            return false;
        }
    }
}
