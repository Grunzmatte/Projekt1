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

    // Max + Dome
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

        //Max
        internal static string Name // Methode zum Namen Setzten
        {
            get { if (name != null) return name; else return ""; } 
            set { if (!nameSet) { name = value; nameSet = true; } } 
        }

        //Max
        internal static int Health // Methode um die Health zu verändern und abzufragen
        {
            get { return health; }
            set
            {
                if (value > maxHealth) health = maxHealth;
                else if (value <= 0) health = 0;
                else health = value;
            }
        }

        //Max
        internal static int Potion // Methode zum Anzahl der Tränke ändern und abfragen
        {
            get { return ammountPotion; }
            set
            {
                if (value > maxAmmountPotion) ammountPotion = maxAmmountPotion;
                else if (value <= 0) ammountPotion = 0;
                else ammountPotion = value;
            }
        }

        //Max
        internal static int MaxPotion // Methode zum Anzahl der Maximalen Tränke ändern und abfragen
        {
            get { return maxAmmountPotion; }
            set { maxAmmountPotion += value; }
        }
        
        //Dome + Max
        internal static int Gold // Methode zum Anzahl des Goldes ändern und abfragen
        {
            get { return gold; }
            set { gold = value; }
        }

        //Dome + Max
        internal static string SetName() // Der Spieler wird nach seinem Namen gefragt
        {
            Console.Write("\n\n\tDu wachst in einem dunklen Gang mit Kopfschmerzen \n\tund einer Wunde am Kopf auf. \n\n\tWeißt du noch wie dein Name ist ?");
            Console.WriteLine("\n\t╔═════════════════════════════╗");
            Console.WriteLine("\t║                             ║");
            Console.WriteLine("\t╚═════════════════════════════╝");
            Console.Write("\t ");
            Console.CursorTop -= 2; //2 Zeilen nach oben
            name = CheckName(); ;
            //Console.CursorTop += 2; //nach der eingabe wieder 2 Zeilen runter damit Grafik nicht zerstört wird
                        
            Console.WriteLine("\n\tGut, immerhin etwas.");
            Function.HorizontalRow();
            Console.WriteLine("\n\tDu schaust ob irgendwas in deiner Tasche ist.\n\tDu findest in deiner Tasche einen Heiltrank.");
            return name;
        }

        //Dome
        private static string CheckName() //Prüft ob Namenseingabe zulässig ist;
        {
            string name = "";
            Position textPosition = new Position();
            textPosition.Spalte = (uint)Console.CursorLeft;
            textPosition.Zeile = (uint)Console.CursorTop;
            name = Console.ReadLine();
            while (name.Length == 0 || NameContainsNumbers(name))   //Solange Name Sonderzeichen / Nummern enthält oder die länge 0 hat ist er unzulässig
            {
                Console.CursorTop += 2;
                Console.CursorLeft = 0;
                Console.Write("\tEingabe ungültig! Bitte neuen Namen eingeben.");
                Console.CursorTop = (int)textPosition.Zeile;
                Console.CursorLeft = (int)textPosition.Spalte;
                Console.Write("                             "); //vorherige eingabe aus der Console löschen.
                Console.CursorTop = (int)textPosition.Zeile;
                Console.CursorLeft = (int)textPosition.Spalte;
                name = Console.ReadLine();

            }
            Console.CursorTop += 2;
            Console.CursorLeft = 0;
            Console.WriteLine("\tEingabe Gültig!                                 \n");

            return name;
        }

        //Dome
        private static bool NameContainsNumbers(string name)
        {
            for (int positionInString = 0; positionInString < name.Length; positionInString++)
            {
                switch (name[positionInString]) //prüft ob Sonderzeichen / Zahlen im Namen sind (unzulässig!)
                {
                    case 'a':
                        break;
                    case 'A':
                        break;
                    case 'b':
                        break;
                    case 'B':
                        break;
                    case 'c':
                        break;
                    case 'C':
                        break;
                    case 'd':
                        break;
                    case 'D':
                        break;
                    case 'e':
                        break;
                    case 'E':
                        break;
                    case 'f':
                        break;
                    case 'F':
                        break;
                    case 'g':
                        break;
                    case 'G':
                        break;
                    case 'h':
                        break;
                    case 'H':
                        break;
                    case 'i':
                        break;
                    case 'I':
                        break;
                    case 'j':
                        break;
                    case 'J':
                        break;
                    case 'k':
                        break;
                    case 'K':
                        break;
                    case 'l':
                        break;
                    case 'L':
                        break;
                    case 'm':
                        break;
                    case 'M':
                        break;
                    case 'n':
                        break;
                    case 'N':
                        break;
                    case 'o':
                        break;
                    case 'O':
                        break;
                    case 'p':
                        break;
                    case 'P':
                        break;
                    case 'q':
                        break;
                    case 'Q':
                        break;
                    case 'r':
                        break;
                    case 'R':
                        break;
                    case 's':
                        break;
                    case 'S':
                        break;
                    case 't':
                        break;
                    case 'T':
                        break;
                    case 'u':
                        break;
                    case 'U':
                        break;
                    case 'v':
                        break;
                    case 'V':
                        break;
                    case 'w':
                        break;
                    case 'W':
                        break;
                    case 'x':
                        break;
                    case 'X':
                        break;
                    case 'y':
                        break;
                    case 'Y':
                        break;
                    case 'z':
                        break;
                    case 'Z':
                        break;
                    default:        //Unzulässiges Zeichen (Zahl / Sonderzeichen)
                        return true;
                }
            }

            return false;
        }

        //Max
        internal static int MaxHealth // Methode um die Health zu verändern
        {
            get { return maxHealth; }
            set { maxHealth += value; }
        }

    }
}
