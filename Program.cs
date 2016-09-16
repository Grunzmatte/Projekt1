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

            Function.openInventory();

            //Solange der spieler nicht escape drückt oder stirbt geht das spiel weiter
            while (!ConsoleKeyInfo.Equals(ConsoleKey.Escape,taste) && !(Charakter.Health == 0) )
            {
                Room room = new Room();
                Console.WriteLine("\n\tDu kommst an eine(n) " + room.Type.name + " Raum");
                
                Function.roomContent(room, minProzent, maxProzent, enemyInRoom,ref taste);

                
                Console.WriteLine("\tIn welche richtung möchtest du gehen ? [links | geradeaus | rechts] ");
                taste = Console.ReadKey().Key;
                while (!ConsoleKeyInfo.Equals(ConsoleKey.LeftArrow, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.RightArrow, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.UpArrow, taste))
                {
                    Console.CursorLeft = 0;
                    taste = Console.ReadKey().Key;
                }
                Console.CursorLeft = 0;

                Function.openInventory();
            }


            Console.ReadKey();
        }
    }
}
