using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerGame
{
    class Farmer
    {
        private string farmer = Direction.North.ToString();
        private ArrayList northBank = new ArrayList { "FOX", "CHICKEN", "GRAIN" };
        private ArrayList southBank = new ArrayList();

        private enum Direction { North, South };

        //properties
        public ArrayList NorthBank
        {
            get { return northBank; }
            //set { northBank = value; }
        }

        public ArrayList SouthBank
        {
            get { return southBank; }
            //set { southBank = value; }
        }

        public string TheFarmer
        {
            get { return farmer; }
            set { farmer = value; }
        }

        //Functions
        public void resetAll()
        {
            farmer = Direction.North.ToString();
            northBank = new ArrayList { "FOX", "CHICKEN", "GRAIN" };
            southBank = new ArrayList();
            Console.ResetColor();
        }

        public Boolean AnimalAteFood()
        {
            Console.Write("\t");
            if (TheFarmer == "North")
            {
                if ((SouthBank.Contains("CHICKEN") && SouthBank.Contains("GRAIN")))
                {
                    Console.WriteLine("The Chicken ate the Grain!");
                    return true;
                }
                else if ((SouthBank.Contains("CHICKEN") && SouthBank.Contains("FOX")))
                {
                    Console.WriteLine("The Fox ate the Chicken!");
                    return true;
                }
            }
            else if (TheFarmer == "South")
            {
                if ((NorthBank.Contains("CHICKEN") && NorthBank.Contains("GRAIN")))
                {
                    Console.WriteLine("The Chicken ate the Grain!");
                    return true;
                }
                else if ((NorthBank.Contains("CHICKEN") && NorthBank.Contains("FOX")))
                {
                    Console.WriteLine("The Fox ate the Chicken!");
                    return true;
                }
            }
            return false;
        }

        public Boolean DetermineWin()
        {
            if (SouthBank.Count > 2)
            {
                Console.WriteLine("\tYou have successfully completed the game!! CONGRATULATIONS!!");
                return true;
            }

            return false;
        }

        public void Move(string name)
        {
            name = name.ToUpper();

            if (name.Length > 0)
            {
                if (TheFarmer == "North" && NorthBank.Contains(name))
                {
                    NorthBank.Remove(name);
                    SouthBank.Add(name);
                    TheFarmer = Direction.South.ToString();
                }
                else if (TheFarmer == "South" && SouthBank.Contains(name))
                {
                    SouthBank.Remove(name);
                    NorthBank.Add(name);
                    TheFarmer = Direction.North.ToString();
                }
            }
            else
            {
                //move farmer
                if (TheFarmer == "North")
                {
                    TheFarmer = Direction.South.ToString();
                }
                else if (TheFarmer == "South")
                {
                    TheFarmer = Direction.North.ToString();
                }
            }

        }
    }
}
