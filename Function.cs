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
    }
}
