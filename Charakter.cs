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
        private static int ammountpotion = 1; // Anzahl an Tränken 
        private static int maxammountpotion = 3; // Maximale Anuahl an Tränken
        private static bool nameSet = false; // Wurde der Name schon gesetzt
        internal static Weapon weapon; // Waffe 


        internal static string Name // Methode zum Namen Setzten
        {
            get { if (name != null) return name; else return ""; } 
            set { if (!nameSet) { name = value; nameSet = true; } } 
        }

        internal static int Health // Methode um die Health zu verändern
        {
            get { return health; }
            set { if (health + value > maxhealth)  health = maxhealth;  else  health += value;  }
        }

        internal static int Potion // Methode zum Anzahl der Tränke ändern
        {
            get { return ammountpotion; }
            set { if (ammountpotion + value > maxammountpotion)  ammountpotion = maxammountpotion;  else  ammountpotion  += value;  }
        }

       


    }
}
