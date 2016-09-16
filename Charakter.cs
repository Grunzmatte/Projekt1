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
        private static int health = 20; // Spieler Hp
        private static int maxHealth = 25; // Maximale Spieler Hp
        public static int ammountPotion = 1; // Anzahl an Tränken 
        private static int maxAmmountPotion = 3; // Maximale Anuahl an Tränken
        private static bool nameSet = false; // Wurde der Name schon gesetzt
        private static int gold = 0;
        internal static Weapon weapon; // Waffe 


        internal static string Name // Methode zum Namen Setzten
        {
            get { if (name != null) return name; else return ""; } 
            set { if (!nameSet) { name = value; nameSet = true; } } 
        }

        internal static int Health // Methode um die Health zu verändern und abzufragen
        {
            get { return health; }
            set { if (health + Items.potionHeal > maxHealth)  health = maxHealth;  else  health += Items.potionHeal;  }
        }

        internal static int Potion // Methode zum Anzahl der Tränke ändern und abfragen
        {
            get { return ammountPotion; }
            set { if (ammountPotion + Items.potion > maxAmmountPotion)  ammountPotion = maxAmmountPotion;  else  ammountPotion  += Items.potion;}
        }

        internal static int MaxPotion // Methode zum Anzahl der Maximalen Tränke ändern und abfragen
        {
            get { return maxAmmountPotion; }
            set { maxAmmountPotion += value; }
        }

        internal static int Gold // Methode zum Anzahl des Goldes ändern und abfragen
        {
            get { return gold; }
            set { gold += value; }
        }

        internal static string setName() // Der Spieler wird nach seinem Namen gefragt
        {
            Console.Write("\n\n\tDu wachst in einem dunklen Gang mit Kopfschmerzen \n\tund einer Wunde am Kopf auf. \n\n\tWeißt du noch wie dein Name ist ? \n\n\t");
            Console.WriteLine("\n\tGut, immerhin etwas.\n");
            Function.horizontalRow();
            Console.WriteLine("\n\tDu schaust ob irgendwas in deiner Tasche ist.\n\tDu findest in deiner Tasche einen Heiltrank.\n");
            return name;
        }

        internal static int MaxHealth // Methode um die Health zu verändern
        {
            get { return maxHealth; }
            set { maxHealth += value; }
        }

    }
}
