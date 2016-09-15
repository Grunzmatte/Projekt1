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
            int maxProzent = 100;   //Maximale Random Prozent
            int minProzent = 1;     //Mindest Random Prozent 
            int enemyInRoom = 70;   //Wahrscheinlichkeit das beim looten ein Gegner erscheint
            Random random = new Random();
            Position schrift = new Position();
            ConsoleKey Taste;

            // Namenseingabe
            Charakter.setName();

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
            Console.ReadKey();
            
            //Solange der spieler nicht escape drückt oder stirbt geht das spiel weiter
            while (!ConsoleKeyInfo.Equals(ConsoleKey.Escape,Taste) && !(Charakter.Health == 0) )
            {
                Room room = new Room();
                Console.WriteLine("Du kommst an eine(n)" + room.type);
                if (room.type == "Raum")
                {
                    Console.WriteLine("Möchtest du versuchen den Raum zu durchsuchen? Es könte ein Gegner auf dich lauern!");
                        Taste = Console.ReadKey().Key;
                    while (!ConsoleKeyInfo.Equals(ConsoleKey.Y, Taste) && !ConsoleKeyInfo.Equals(ConsoleKey.N, Taste) && !ConsoleKeyInfo.Equals(ConsoleKey.Escape, Taste))
                    {
                        Console.CursorLeft = 0;
                        Taste = Console.ReadKey().Key;
                    }
                    Console.CursorLeft = 0;
                    if (!ConsoleKeyInfo.Equals(ConsoleKey.Escape, Taste))
                    {
                        break;
                    }
                    else if (ConsoleKeyInfo.Equals(ConsoleKey.Y, Taste))
                    {
                        //Raum looten
                        //Gegner erscheint 70% wahrs.

                        Console.WriteLine("Du gehst in den Raum und fängst an zu looten");
                        if (random.Next(minProzent, maxProzent+1) <= enemyInRoom)
                        {
                            Console.WriteLine("Ein Gegner ist erschienen");

                        }
                        else
                        {
                            Console.WriteLine("Du lootest den Raum und hattest Glück, kein Gegner ist erschienen");
                        }
                        
                    }
                    else
                    {
                        //Raum wird nicht gelootet
                        //gegner erscheint 30% wahrs.

                        Console.WriteLine("Du durchquerst den Raum ohne zu looten");
                        if (random.Next(minProzent, maxProzent + 1) > enemyInRoom)
                        {
                            Console.WriteLine("Ein Gegner ist erschienen");
                        }
                        else
                        {
                            Console.WriteLine("Du durchquerst den Raum und hattest Glück");
                        }
                       
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
                    Console.WriteLine("In welche richtung möchtest du gehen ? [links | geradeaus | rechts] ");
                    Taste = Console.ReadKey().Key;
                }
                
            }


            Console.ReadKey();
        }
    }
}
