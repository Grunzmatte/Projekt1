using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{   
    /// <summary>
    /// Charakter wird hier eingestellt
    /// </summary>


        // Max
    static class Charakter
    {
        private static string name; // Spieler Name
        private static int health = 25; // Spieler Hp
        private static int maxhealth = 25; // Maximale Spieler Hp
        private static int ammountpotion = 1;
        private static int maxammountpotion = 3;
        private static bool nameSet = false;

        internal static string Name
        {
            get { if (name != null) return name; else return ""; }
            set { if (!nameSet) { name = value; nameSet = true; } }
        }

        internal static int Health
        {
            get { return health; }
            set { if (health + value > maxhealth)  health = maxhealth;  else  health += value;  }
        }

        internal static int Potion
        {
            get { return ammountpotion; }
            set { if (ammountpotion + value > maxammountpotion)  ammountpotion = maxammountpotion;  else  ammountpotion  += value;  }
        }

       


    }
}
