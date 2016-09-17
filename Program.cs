using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class Program
    {
        //Alle
        static void Main(string[] args)
        {
            int maxProzent = 100;               //Maximale Random Prozent
            int minProzent = 1;                 //Mindest Random Prozent 
            int enemyInRoom = 70;               //Wahrscheinlichkeit das beim looten ein Gegner erscheint
            Random random = new Random();       //Zufalls zahlen generator
            Position schrift = new Position();  
            ConsoleKey taste = ConsoleKey.Spacebar; //Initialisiert mit zufallstaste (leertaste)

            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            

            // Namenseingabe
            Charakter.SetName();

            // Der Char bekommt eine Waffe
            Function.PickWeapon(ref taste);
            if (!ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch wenn beim Waffenwählen Escape gedrückt wurde
            {
                Function.CharakterStats();
                
                Console.WriteLine("\tDu hörst von Rechts Geräusche und folgst vorsichtig dem Gang. ");
                Function.HorizontalRow();
                
                Function.OpenInventory(ref taste);
            }
            //Solange der spieler nicht escape drückt oder stirbt geht das spiel weiter
            while (!ConsoleKeyInfo.Equals(ConsoleKey.Escape,taste) && !(Charakter.Health == 0) )
            {
                //Neuer Raum wird erzeugt
                Room room = new Room();
                Console.WriteLine("\tDu gehst weiter und kommst an einen " + room.Type.name + " Raum");
                
                //Raum wird abgearbeitet (Kampf ? / Looten?)
                Function.RoomContent(room, minProzent, maxProzent, enemyInRoom,ref taste);
                Function.HorizontalRow();

                //Raum beendet abfrage in welche Richtung man als nächste will
                Console.Write("\tIn welche Richtung möchtest du gehen ? \n\t[links | geradeaus | rechts] : ");
                schrift.Spalte = (uint)Console.CursorLeft;
                schrift.Zeile = (uint)Console.CursorTop;

                //Abfrage ob eingabe zulässig ist
                taste = Function.KeyQuestion(ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.UpArrow);
                if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))
                    break;

                Console.CursorLeft = (int)schrift.Spalte;
                Console.CursorTop = (int)schrift.Zeile;

                if (ConsoleKeyInfo.Equals(ConsoleKey.LeftArrow, taste))
                    Console.WriteLine("links");
                else if (ConsoleKeyInfo.Equals(ConsoleKey.RightArrow, taste))
                    Console.WriteLine("rechts");
                else
                    Console.WriteLine("geradeaus");


                //Funktion die frägt ob man vor dem nächsten Raum nochmal sein Inventar benutzen will
                Function.HorizontalRow();
                Function.OpenInventory(ref taste);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\n");
            }
            //Highscorliste hier einfügen
            

        }
    }
}
