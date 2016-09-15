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
        private static int maxHealth = 25; // Maximale Spieler Hp
        private static int ammountPotion = 1; // Anzahl an Tränken 
        private static int maxAmmountPotion = 3; // Maximale Anuahl an Tränken
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
            set { if (health + value > maxHealth)  health = maxHealth;  else  health += value;  }
        }

        internal static int Potion // Methode zum Anzahl der Tränke ändern
        {
            get { return ammountPotion; }
            set { if (ammountPotion + value > maxAmmountPotion)  ammountPotion = maxAmmountPotion;  else  ammountPotion  += value;  }
        }

        internal static string setName()
        {
            Console.WriteLine("Du wachst in einem dunklen Gang mit Kopfschmerzen und einer Wunde am Kopf auf. Weißt du noch wie dein Name ist ? \n");
            name = Console.ReadLine();
            Console.WriteLine("Gut, immerhin etwas. Du schaust ob irgendwas in deiner Tasche ist.\nDu findest in deiner Tasche einen Heiltrank.\n");
            return name;
        }

       


    }
}
