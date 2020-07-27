using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start Game
            FarmerUI UI = new FarmerUI();
            UI.GamePlay();
        }
    }
}
