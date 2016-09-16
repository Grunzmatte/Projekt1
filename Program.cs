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
            ConsoleKey taste;

            // Namenseingabe
            Charakter.setName();

            // Der Char bekommt eine Waffe
            Function.pickWeapon();
            Function.stats();

            Function.horizontalRow();
            Console.WriteLine(" \n\tDu hörst von Rechts Geräusche und folgst vorsichtig dem Gang. ");
            taste = Console.ReadKey().Key;
            
            //Solange der spieler nicht escape drückt oder stirbt geht das spiel weiter
            while (!ConsoleKeyInfo.Equals(ConsoleKey.Escape,taste) && !(Charakter.Health == 0) )
            {
                Room room = new Room();
                Console.WriteLine("\n\tDu kommst an eine(n) " + room.Name + " Raum");
                if (room.Name == Room.Names[0])
                {
                    // kleiner Raum 25% Chance auf Loot

                    Console.WriteLine("\tMöchtest du versuchen den Raum zu durchsuchen? \n\tEs könte ein Gegner auf dich lauern! [y|n]");
                    taste = Console.ReadKey().Key;
                    while (!ConsoleKeyInfo.Equals(ConsoleKey.Y, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.N, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))
                    {
                        Console.CursorLeft = 0;
                        taste = Console.ReadKey().Key;
                    }
                    Console.CursorLeft = 0;
                    if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))
                    {
                        break;
                    }
                    else if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
                    {
                        //Raum looten
                        //Gegner erscheint 70% wahrs.

                        Console.WriteLine("\tDu gehst in den Raum und fängst an zu looten\n");
                        if (random.Next(minProzent, maxProzent+1) <= enemyInRoom)
                        {
                            Function.fight();
                        }
                        else
                        {
                            Console.WriteLine("\tDu lootest den Raum und hattest Glück,\n\tkein Gegner ist erschienen\n");
                        }
                        
                    }
                    else
                    {
                        //Raum wird nicht gelootet
                        //gegner erscheint 30% wahrs.

                        Console.WriteLine("\tDu durchquerst den Raum ohne zu looten\n");
                        if (random.Next(minProzent, maxProzent + 1) > enemyInRoom)
                        {
                            Function.fight();
                        }
                        else
                        {
                            Console.WriteLine("\tDu durchquerst den Raum und hattest Glück\n");
                        }
                       
                    }

                }
                else if (room.Name == Room.Names[1])
                {
                    // mittlerer Raum = 50% Chance auf Loot
                    Function.openInventory();

                    if (random.Next(0,2) == 1)
                    {
                        //Gegner erscheint
                        Function.fight();
                    }
                    else
                    {
                        //nächster Raum
                    }

                    
                    Console.WriteLine("\tIn welche richtung möchtest du gehen ? [links | geradeaus | rechts] ");
                    taste = Console.ReadKey().Key;
                    while (!ConsoleKeyInfo.Equals(ConsoleKey.LeftArrow, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.RightArrow, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.UpArrow, taste))
                    {
                        Console.CursorLeft = 0;
                        taste = Console.ReadKey().Key;
                    }
                }
                else
                {
                    // großer Raum, 75% Chance auf Loot
                }
                
            }


            Console.ReadKey();
        }
    }
}
