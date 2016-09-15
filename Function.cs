using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    /// <summary>
    /// Hier werden alle Funktionen gespeichert
    /// </summary>

    class Function
    {

        private static ConsoleKey Taste;

        internal static void pickWeapon()
        { 
            Console.WriteLine("Du siehst vor dir auf dem Boden einen Gegenstand der sich als Waffe eignet möchtest du ihn aufheben ? [y/n]\n");
            Taste = Console.ReadKey().Key;
            while (!ConsoleKeyInfo.Equals(ConsoleKey.Y, Taste) && !ConsoleKeyInfo.Equals(ConsoleKey.N, Taste))
            {
                Console.CursorLeft = 0;
                Taste = Console.ReadKey().Key;
            }
                Console.CursorLeft = 0;
            if (ConsoleKeyInfo.Equals(ConsoleKey.Y, Taste))
            {
                Charakter.weapon = new Weapon();
                Console.WriteLine(" \nDu hast ein(e/nen) " + Charakter.weapon.Name + " aufgehoben.");
                
            }
            else 
            {
                Charakter.weapon = new Weapon(Charakter.Name);
                Console.WriteLine(" \nDann kämpfe halt mit deinen Fäusten du Depp!");
                
            }


        }

        internal static void stats()
        {
            int statWindowWidth = 56;
            Console.WriteLine("\tDu schaust wie viel Gold du bereits gesammelt hast.\n\tNun tastest du deinen Körper noch auf Verletzungen ab\n\tund schaust nach wie viele Heiltränke dir noch bleiben.");
            Console.WriteLine("\t╔═══════════════════════════════════════════════╗");            
            Console.Write("\t║Status:");
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Charakter Gesundheit bei: [{0}|{1}]", Charakter.Health,Charakter.MaxHealth);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Heiltränke: [{0}|{1}]\t\t\t\t║", Charakter.Potion, Charakter.MaxPotion);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Gold: {0}\t\t\t\t\t║", Charakter.Gold);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Waffe: {0}\t\t\t\t║", Charakter.weapon.Name);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Waffenschaden: {0}\t\t\t\t║", Charakter.weapon.Damage);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Angriffsgeschwindigkeit: {0}\t\t\t║", Charakter.weapon.Speed);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.WriteLine("\t╚═══════════════════════════════════════════════╝");
        }
    }
}
