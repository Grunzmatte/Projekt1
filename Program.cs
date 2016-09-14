using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Position schrift = new Position();
            ConsoleKey Taste;

            // Namenseingabe
            Console.WriteLine("Du wachst in einem dunklen Gang mit Kopfschmerzen und einer Wunde am Kopf auf. Weißt du noch wie dein Name ist ? \n");
            Charakter.Name = Console.ReadLine();
            Console.WriteLine("Gut, immerhin etwas. Du schaust ob irgendwas in deiner Tasche ist.\nDu findest in deiner Tasche einen Heiltrank.\n");

            Console.WriteLine("Du siehst vor dir auf dem Boden einen Gegenstand der sich als Waffe eignet möchtest du ihn aufheben ? [y/n]\n");
            schrift.Spalte = (uint)Console.CursorLeft;
            schrift.Zeile = (uint)Console.CursorTop;
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

            Console.WriteLine(" \nDu hörst von Rechts Geräusche und folgst vorsichtig dem Gang. ");
            
            //Solange der spieler nicht escape drückt oder stirbt geht das spiel weiter
            while (!ConsoleKeyInfo.Equals(ConsoleKey.Escape,Taste) || Charakter.Health > 0 )
            {
                Room room = new Room();
                Console.WriteLine("Du kommst an eine(n)" + room.type);
                if (room.type == "Raum")
                {
                    Console.WriteLine("Möchtest du versuchen den Raum zu durchsuchen? Es könte ein Gegner auf dich lauern!");
                        Taste = Console.ReadKey().Key;
                    while (!ConsoleKeyInfo.Equals(ConsoleKey.Y, Taste) && !ConsoleKeyInfo.Equals(ConsoleKey.N, Taste))
                    {
                        Console.CursorLeft = 0;
                        Taste = Console.ReadKey().Key;
                    }
                    Console.CursorLeft = 0;
                    if (ConsoleKeyInfo.Equals(ConsoleKey.Y, Taste))
                    {
                        //Raum looten
                        //Gegner erscheint 70% wahrs.

                    }
                    else
                    {
                        //Raum wird nicht gelootet
                        //gegner erscheint 30% wahrs.
                    }

                }
                else
                {
                    if (random.Next(0,2) == 1)
                    {
                        //Gegner erscheint
                    }
                    else
                    {
                        //nächster Raum
                    }

                }
            }


            Console.ReadKey();
        }
    }
}
