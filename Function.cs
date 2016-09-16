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
        
        //Dome + Max
        internal static void pickWeapon()
        {
            ConsoleKey taste;
            Console.WriteLine("\tDu siehst vor dir auf dem Boden einen Gegenstand der \n\tsich als Waffe eignet möchtest du ihn aufheben ? [y/n]\n");
            taste = Console.ReadKey().Key;
            while (!ConsoleKeyInfo.Equals(ConsoleKey.Y, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.N, taste))
            {
                Console.CursorLeft = 0;
                taste = Console.ReadKey().Key;
            }
                Console.CursorLeft = 0;
            if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
            {
                Charakter.weapon = new Weapon();
                Console.WriteLine(" \n\tDu hast ein(e/nen) " + Charakter.weapon.Name + " aufgehoben.");
                
            }
            else 
            {
                Charakter.weapon = new Weapon(Charakter.Name);
                Console.WriteLine(" \n\tDann kämpfe halt mit deinen Fäusten du Depp!");
                Function.horizontalRow();
                
            }


        }

        //Dome
        internal static void stats()
        {
            int statWindowWidth = 56;   //position des Consolenzeigers für das letzte Zeichen des Statusfensters ("║")
            Console.WriteLine("\tDu schaust wie viel Gold du bereits gesammelt hast.\n\tNun tastest du deinen Körper auf Verletzungen ab\n\tund schaust nach wie viele Heiltränke dir noch bleiben.");
            Console.WriteLine("\t╔═══════════════════════════════════════════════╗");            
            Console.Write("\t║Status von {0}:",Charakter.Name);
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

        //Dome
        internal static void fight()
        {
            int statWindowWidth = 56;   //position des Consolenzeigers für das letzte Zeichen des Statusfensters ("║")
            Enemy enemy = new Enemy();
            Random random = new Random();
            int directions = 5;             //Anzahl von Angriffsrichtungen
            ConsoleKey taste;
            int sumSpeedEnemy = 0;      //Summe der Angriffsgeschwindigkeit über alle Angriffe hinweg
            int sumSpeedPlayer = 0;

            Function.horizontalRow();
            Console.WriteLine("\n\tEin(e) {0} erscheint auf einmal vor dir und greift dich an!\n", enemy.Name);
            enemyStats(enemy);          //Statuswerte des Gegners werden angezeigt

            sumSpeedEnemy += enemy.Weapon.Speed;
            sumSpeedPlayer += Charakter.weapon.Speed;

            while (Charakter.Health > 0 && enemy.Health > 0)    //Solange der Spieler und der Gegner noch leben geht der Kampf weiter.
            {
                
                if (sumSpeedEnemy < sumSpeedPlayer)         //der Kämpfer mit der kleineren geschwindigkeits summe greift zuerst an
                {
                    //Gegner greift an
                    sumSpeedEnemy += enemy.Weapon.Speed;
                    Console.WriteLine();
                    Function.horizontalRow();
                    Console.WriteLine("\n\tDer Gegner greift an verteidige dich!");
                    Console.WriteLine("\t[1] Oben");
                    Console.WriteLine("\t[2] Links");
                    Console.WriteLine("\t[3] Mitte");
                    Console.WriteLine("\t[4] Rechts");
                    Console.WriteLine("\t[5] Unten\n\n");
                    taste = Console.ReadKey().Key;
                    int direction = random.Next(1, directions + 1);
                    while(!ConsoleKeyInfo.Equals(ConsoleKey.D1,taste) && !ConsoleKeyInfo.Equals(ConsoleKey.D2, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.D3, taste)&& !ConsoleKeyInfo.Equals(ConsoleKey.D4, taste)&& !ConsoleKeyInfo.Equals(ConsoleKey.D5, taste))
                    {
                        Console.CursorLeft = 0;
                        taste = Console.ReadKey().Key;
                    }
                    switch (direction)
                    {
                        case 1:
                            Console.WriteLine("\tBlocken fehlgeschlagen!");
                            Console.WriteLine("\tDu nimmst {0} Schaden.", enemy.Weapon.Damage);
                            Charakter.Health -= enemy.Weapon.Damage;
                            break;
                        case 2:
                            Console.WriteLine("\tAngriff leicht abgewehrt!");
                            Console.WriteLine("\tDu nimmst {0} Schaden.", enemy.Weapon.Damage / 2);
                            Charakter.Health -= enemy.Weapon.Damage/2;
                            break;
                        case 3:
                            Console.WriteLine("\tAngriff erfolgreich ausgewichen!");
                            break;                        
                        case 4:
                            Console.WriteLine("\tAngriff leicht abgewehrt!");
                            Console.WriteLine("\tDu nimmst {0} Schaden.", enemy.Weapon.Damage / 2);
                            Charakter.Health -= enemy.Weapon.Damage / 2;

                            break;
                        case 5:
                            Console.WriteLine("\tBlocken fehlgeschlagen!");
                            Console.WriteLine("\tDu nimmst {0} Schaden.", enemy.Weapon.Damage);
                            Charakter.Health -= enemy.Weapon.Damage;
                            break;
                        default:
                            break;
                    }
                    
                }
                else
                {
                    //Spieler greift an
                    sumSpeedPlayer += Charakter.weapon.Speed;
                    Console.WriteLine();
                    Function.horizontalRow();
                    Console.WriteLine("\n\tDu greifst an!");
                    Console.WriteLine("\tWähle die richtung aus der du angreifst.");
                    Console.WriteLine("\t[1] Oben");
                    Console.WriteLine("\t[2] Links");
                    Console.WriteLine("\t[3] Mitte");
                    Console.WriteLine("\t[4] Rechts");
                    Console.WriteLine("\t[5] Unten\n\n");
                    taste = Console.ReadKey().Key;
                    int direction = random.Next(1, directions + 1);
                    while (!ConsoleKeyInfo.Equals(ConsoleKey.D1, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.D2, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.D3, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.D4, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.D5, taste))
                    {
                        Console.CursorLeft = 0;
                        taste = Console.ReadKey().Key;
                    }
                    switch (direction)
                    {
                        case 1:
                            Console.WriteLine("\tDer gegner blockt den Schlag!");
                            break;
                        case 2:
                            Console.WriteLine("\tAngriff erfolgreich!");
                            Console.WriteLine("\t{0} nimmt {1} Schaden.", enemy.Name, Charakter.weapon.Damage);
                            enemy.Health -= Charakter.weapon.Damage;
                            break;
                        case 3:
                            Console.WriteLine("\tVolltreffer!");
                            Console.WriteLine("\t{0} nimmt {1} Schaden.", enemy.Name, Charakter.weapon.Damage *2);
                            enemy.Health -= Charakter.weapon.Damage*2;
                            break;
                        case 4:
                            Console.WriteLine("\tAngriff erfolgreich!");
                            Console.WriteLine("\t{0} nimmt {1} Schaden.", enemy.Name, Charakter.weapon.Damage);
                            enemy.Health -= Charakter.weapon.Damage;
                            break;
                        case 5:
                            Console.WriteLine("\tDer Gegner ist ausgewichen!");
                            break;
                        default:
                            break;
                    }
                }
            }

            if (Charakter.Health == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\t\tDu bist gestorben!");
            }
            else
            {
                Console.WriteLine("\n\tDu hast {0} zusammengeschlagen!\n\tWeiter so ;)",enemy.Name);
                Console.WriteLine("\n\t╔═══════════════════════════════════════════════╗");
                Console.Write("\t║Deine Waffe: {0}", Charakter.weapon.Name);
                Console.CursorLeft = statWindowWidth;
                Console.WriteLine("║");
                Console.Write("\t║Schaden: {0}", Charakter.weapon.Damage);
                Console.CursorLeft = statWindowWidth;
                Console.WriteLine("║");
                Console.Write("\t║Geschwindigkeit: {0}", Charakter.weapon.Speed);
                Console.CursorLeft = statWindowWidth;
                Console.WriteLine("║");
                Console.WriteLine("\t╠═══════════════════════════════════════════════╣");
                Console.Write("\t║Gegner Waffe: {0}", enemy.Weapon.Name);
                Console.CursorLeft = statWindowWidth;
                Console.WriteLine("║");
                Console.Write("\t║Schaden: {0}", enemy.Weapon.Damage);
                Console.CursorLeft = statWindowWidth;
                Console.WriteLine("║");
                Console.Write("\t║Geschwindigkeit: {0}", enemy.Weapon.Speed);
                Console.CursorLeft = statWindowWidth;
                Console.WriteLine("║");
                Console.WriteLine("\t╚═══════════════════════════════════════════════╝");
                Console.WriteLine("\n\tMöchtest du die Waffe des Gegners looten? [y|n]");
                taste = Console.ReadKey().Key;
                while (!ConsoleKeyInfo.Equals(ConsoleKey.Y, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.N, taste) )
                {
                    Console.CursorLeft = 0;
                    taste = Console.ReadKey().Key;
                }
                if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
                {
                    Console.WriteLine("\n\tDu hast nun eine neue Waffe benutze sie weiße!\n\n");
                    Charakter.weapon = enemy.Weapon;

                }
            }
            Function.horizontalRow();
        }

        //Dome
        internal static void enemyStats(Enemy enemy)
        {
            int statWindowWidth = 56;   //position des Consolenzeigers für das letzte Zeichen des Statusfensters ("║")
            Console.WriteLine("\t╔═══════════════════════════════════════════════╗");
            Console.Write("\t║Status von {0}:",enemy.Name);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Gegner Gesundheit bei: [{0}|{1}]", enemy.Health, enemy.MaxHealth);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Waffe: {0}", enemy.Weapon.Name);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Waffenschaden: {0}", enemy.Weapon.Damage);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Angriffsgeschwindigkeit: {0}", enemy.Weapon.Speed);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.WriteLine("\t╚═══════════════════════════════════════════════╝");
        }
        //Dome
        internal static void horizontalRow()
        {
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        //Sascha
        internal static void openInventory()
        {
            ConsoleKey taste; 
            Console.WriteLine("\tMöchtest du dein Inventar aufrufen bevor du weitergehst? [y/n]\n");
            taste = Console.ReadKey().Key;
            Console.CursorLeft = 0;
                    if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
                    {
                Function.stats();
                Console.WriteLine("\tMöchtest du einen Heiltrank benutzen? [y/n]\n");
                taste = Console.ReadKey().Key;
                Console.CursorLeft = 0;

                if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
                {
                    Function.healing();

                    Function.stats();

                }
                Console.ReadKey();
            }
        }
        //Max
        internal static void healing()
        {

            if (Charakter.Potion > 0 && Charakter.Health < Charakter.MaxHealth )
            {
                Charakter.Health += Items.potionHeal;
                Charakter.Potion--;
            }

            else if (Charakter.Potion == 0)
            {
                Console.WriteLine("\tDu hast keine Tränke übrig!");
            }
            else
            {
                Console.WriteLine("\tDu haste volles Leben, du kannst dich nicht Heilen!");
            }

            
        }
        //Max
        internal static void loot(int goldCap)
        {
            Random random = new Random();
            int chance = 100; // 100% MaxChance
            int potionChance = 30;
            int gold = 0;

            if (random.Next(1, chance + 1) <= potionChance)
            {
                if(Charakter.Potion <= Charakter.MaxPotion)
                {
                    Charakter.Potion++;
                    Console.WriteLine("\tDu hast einen Heiltrank gefunden");
                }
                else if (Charakter.Potion == Charakter.MaxPotion && Charakter.Health < Charakter.MaxHealth)
                {
                    Function.healing();
                    Console.WriteLine("\tDu hast einen Heiltrank gefunden und dich sofort damit geheilt!");
                    Charakter.Potion++;
                }
                else
                {
                    Console.WriteLine("\tDu hast einen Heiltrank gefunden, aber dein Inventar ist voll!");
                }
            }

            gold = random.Next(1, goldCap + 1);
            Charakter.Gold += gold;
            Console.WriteLine("\tDu hast {0} Gold gefunden.", gold);

        }

        internal static void roomContent(Room room, int minProzent, int maxProzent, int enemyInRoom,ref  ConsoleKey taste )
        {
            Random random = new Random();

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
                return;
            }

            else if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
            {
                //Raum looten
                //Gegner erscheint 70% wahrs.

                Console.WriteLine("\tDu gehst in den Raum und fängst an zu looten\n");

                if (random.Next(minProzent, maxProzent + 1) <= enemyInRoom)
                {
                    Function.fight();
                    Function.loot(room.Type.maxAmmountGold);

                }
                else
                {
                    Console.WriteLine("\tDu lootest den Raum und hattest Glück,\n\tkein Gegner ist erschienen\n");
                    Function.loot(room.Type.maxAmmountGold);

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
    }
}
