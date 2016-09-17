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
        internal static void PickWeapon(ref ConsoleKey taste)
        {
            Console.Write("\n\tDu siehst vor dir auf dem Boden einen Gegenstand der \n\tsich als Waffe eignet möchtest du ihn aufheben ?\n\t[y/n] : ");
            taste = YNQuestion();
            if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                return;

            if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
            {
                Charakter.weapon = new Weapon();
                Console.WriteLine("\n\tDu hast ein(e/nen) " + Charakter.weapon.Name + " aufgehoben.");                
            }
            else 
            {
                Charakter.weapon = new Weapon(Charakter.Name);
                Console.WriteLine("\n\tDann kämpfe halt mit deinen Fäusten du Depp!");
                Function.HorizontalRow();                
            }
        }

        //Dome
        internal static void CharakterStats()
        {
            int statWindowWidth = 56;   //position des Consolenzeigers für das letzte Zeichen des Statusfensters ("║")
            Function.HorizontalRow();
            Console.WriteLine("\t╔═══════════════════════════════════════════════╗");            
            Console.Write("\t║Status von {0}:",Charakter.Name);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Charakter Gesundheit bei: [{0}|{1}]", Charakter.Health,Charakter.MaxHealth);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Heiltränke: [{0}|{1}]", Charakter.Potion, Charakter.MaxPotion);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Gold: {0}", Charakter.Gold);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Waffe: {0}", Charakter.weapon.Name);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Waffenschaden: {0}", Charakter.weapon.Damage);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.Write("\t║Angriffsgeschwindigkeit: {0}", Charakter.weapon.Speed);
            Console.CursorLeft = statWindowWidth;
            Console.WriteLine("║");
            Console.WriteLine("\t╚═══════════════════════════════════════════════╝");
            Function.HorizontalRow();
        }

        //Dome
        internal static void Fight(ref ConsoleKey taste)
        {
            int statWindowWidth = 56;   //position des Consolenzeigers für das letzte Zeichen des Statusfensters ("║")
            Enemy enemy = new Enemy();
            Random random = new Random();
            int directions = 5;             //Anzahl von Angriffsrichtungen            
            int sumSpeedEnemy = 0;      //Summe der Angriffsgeschwindigkeit über alle Angriffe hinweg
            int sumSpeedPlayer = 0;

            Function.HorizontalRow();
            Console.WriteLine("\tEin(e) {0} erscheint auf einmal vor dir und greift dich an!\n", enemy.Name);
            EnemyStats(enemy);          //Statuswerte des Gegners werden angezeigt

            sumSpeedEnemy += enemy.Weapon.Speed;
            sumSpeedPlayer += Charakter.weapon.Speed;

            while (Charakter.Health > 0 && enemy.Health > 0)    //Solange der Spieler und der Gegner noch leben geht der Kampf weiter.
            {
                
                if (sumSpeedEnemy < sumSpeedPlayer)         //der Kämpfer mit der kleineren geschwindigkeits summe greift zuerst an
                {
                    //Gegner greift an
                    sumSpeedEnemy += enemy.Weapon.Speed;
                    Console.WriteLine();
                    Function.HorizontalRow();
                    Console.WriteLine("\tDer Gegner greift an verteidige dich!");
                    Console.WriteLine("\t[1] Oben");
                    Console.WriteLine("\t[2] Links");
                    Console.WriteLine("\t[3] Mitte");
                    Console.WriteLine("\t[4] Rechts");
                    Console.WriteLine("\t[5] Unten");
                    Console.Write("\t[1|2|3|4|5] : ");

                    int direction = random.Next(1, directions + 1);

                    //Eingabe an sich egal da wert zufällig bestimmt wird
                    taste = KeyQuestion(ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.Escape);
                    if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                        return;

                    switch (direction)
                    {
                        case 1:
                            Console.WriteLine("\n\tBlocken fehlgeschlagen!");
                            Console.WriteLine("\tDu nimmst {0} Schaden.", enemy.Weapon.Damage);
                            Charakter.Health -= enemy.Weapon.Damage;
                            CharakterStats();
                            break;
                        case 2:
                            Console.WriteLine("\n\tAngriff leicht abgewehrt!");
                            Console.WriteLine("\tDu nimmst {0} Schaden.", enemy.Weapon.Damage / 2);
                            Charakter.Health -= enemy.Weapon.Damage/2;
                            CharakterStats();
                            break;
                        case 3:
                            Console.WriteLine("\n\tAngriff erfolgreich ausgewichen!");
                            CharakterStats();
                            break;                        
                        case 4:
                            Console.WriteLine("\n\tAngriff leicht abgewehrt!");
                            Console.WriteLine("\tDu nimmst {0} Schaden.", enemy.Weapon.Damage / 2);
                            Charakter.Health -= enemy.Weapon.Damage / 2;
                            CharakterStats();
                            break;
                        case 5:
                            Console.WriteLine("\n\tBlocken fehlgeschlagen!");
                            Console.WriteLine("\tDu nimmst {0} Schaden.", enemy.Weapon.Damage);
                            Charakter.Health -= enemy.Weapon.Damage;
                            CharakterStats();
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
                    Function.HorizontalRow();
                    Console.WriteLine("\tDu greifst an!");
                    Console.WriteLine("\tWähle die richtung aus der du angreifst.");
                    Console.WriteLine("\t[1] Oben");
                    Console.WriteLine("\t[2] Links");
                    Console.WriteLine("\t[3] Mitte");
                    Console.WriteLine("\t[4] Rechts");
                    Console.WriteLine("\t[5] Unten");
                    Console.Write("\t[1|2|3|4|5] : ");

                    int direction = random.Next(1, directions + 1);

                    //Eingabe an sich egal da Wert zufällig bestimmt wird
                    taste = KeyQuestion(ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5);
                    if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                        return;

                    switch (direction)
                    {
                        case 1:
                            Console.WriteLine("\n\tDer gegner blockt den Schlag!");
                            EnemyStats(enemy);
                            break;
                        case 2:
                            Console.WriteLine("\n\tAngriff erfolgreich!");
                            Console.WriteLine("\t{0} nimmt {1} Schaden.", enemy.Name, Charakter.weapon.Damage);
                            enemy.Health -= Charakter.weapon.Damage;
                            EnemyStats(enemy);
                            break;
                        case 3:
                            Console.WriteLine("\n\tVolltreffer!");
                            Console.WriteLine("\t{0} nimmt {1} Schaden.", enemy.Name, Charakter.weapon.Damage *2);
                            enemy.Health -= Charakter.weapon.Damage*2;
                            EnemyStats(enemy);
                            break;
                        case 4:
                            Console.WriteLine("\n\tAngriff erfolgreich!");
                            Console.WriteLine("\t{0} nimmt {1} Schaden.", enemy.Name, Charakter.weapon.Damage);
                            enemy.Health -= Charakter.weapon.Damage;
                            EnemyStats(enemy);
                            break;
                        case 5:
                            Console.WriteLine("\n\tDer Gegner ist ausgewichen!");
                            EnemyStats(enemy);
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
                taste = ConsoleKey.Escape;
                return;
            }
            else
            {
                HorizontalRow();
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
                Console.Write("\n\tMöchtest du die Waffe des Gegners looten? \n\t[y|n] : ");

                taste = YNQuestion();
                if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                    return;

                if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
                {
                    Console.WriteLine("\n\tDu hast nun eine neue Waffe benutze sie weiße!\n\n");
                    Charakter.weapon = enemy.Weapon;
                }
            }
            Function.HorizontalRow();
        }

        //Dome
        internal static void EnemyStats(Enemy enemy)
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
        internal static void HorizontalRow()
        {
            string horizontalRow = "";

            for (int rowLenghtCounter = 0;rowLenghtCounter<Console.WindowWidth;rowLenghtCounter++)
            {
                horizontalRow += "═";
            }
            Console.WriteLine("\n" + horizontalRow );
        }

        //Sascha
        internal static void OpenInventory(ref ConsoleKey taste)
        {             
            Console.Write("\tMöchtest du dein Inventar aufrufen bevor du weitergehst? \n\t[y/n] : ");
            taste = YNQuestion();
            if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                return;

            if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
            {
                Console.WriteLine("\tDu schaust wie viel Gold du bereits gesammelt hast.\n\tNun tastest du deinen Körper auf Verletzungen ab\n\tund schaust nach wie viele Heiltränke dir noch bleiben.\n");
                Function.CharakterStats();
                Console.Write("\tMöchtest du einen Heiltrank benutzen? \n\t[y/n] : ");
                taste = YNQuestion();
                if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                    return;

                if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
                {
                    Function.Healing();
                    Console.WriteLine("\tDu schaust wie viel Gold du bereits gesammelt hast.\n\tNun tastest du deinen Körper auf Verletzungen ab\n\tund schaust nach wie viele Heiltränke dir noch bleiben.\n");
                    Function.CharakterStats();

                }
            }
        }

        //Max
        internal static void Healing()
        {

            if (Charakter.Potion > 0 && Charakter.Health < Charakter.MaxHealth )
            {
                Charakter.Health += Items.potionHeal;
                Charakter.Potion--;
                Console.WriteLine("\n\tDu hast dich mit einem Trank geheilt!");
                Console.ReadKey();
                Console.CursorLeft = 0;
                Console.Write(" ");
            }

            else if (Charakter.Potion == 0)
            {
                Console.WriteLine("\n\tDu hast keine Tränke übrig!");
                Console.ReadKey();
                Console.CursorLeft = 0;
                Console.Write(" ");
            }
            else
            {
                Console.WriteLine("\n\tDu haste volles Leben, du kannst dich nicht Heilen!");
                Console.ReadKey();
                Console.CursorLeft = 0;
                Console.Write(" ");
            }            
        }

        //Max
        internal static void Loot(int goldCap)
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
                    Function.Healing();
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

        //Max + Dome
        internal static void RoomContent(Room room, int minProzent, int maxProzent, int enemyInRoom,ref  ConsoleKey taste )
        {
            Random random = new Random();

            Console.Write("\n\tMöchtest du versuchen den Raum zu durchsuchen? \n\tEs könte ein Gegner auf dich lauern! \n\t[y|n] : ");
            
            taste = YNQuestion();
            if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                return;

            if (ConsoleKeyInfo.Equals(ConsoleKey.Y, taste))
            {
                //Raum looten
                //Gegner erscheint 70% wahrs.

                Console.WriteLine("\n\tDu gehst in den Raum und fängst an zu looten");

                if (random.Next(minProzent, maxProzent + 1) <= enemyInRoom)
                {
                    Fight(ref taste);
                    if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                        return;
                    Loot(room.Type.maxAmmountGold);
                }
                else
                {
                    Console.WriteLine("\n\tDu lootest den Raum und hattest Glück,\n\tkein Gegner ist erschienen.");
                    HorizontalRow();
                    Loot(room.Type.maxAmmountGold);
                }

            }
            else
            {
                //Raum wird nicht gelootet
                //gegner erscheint 30% wahrs.

                Console.WriteLine("\n\tDu durchquerst den Raum ohne zu looten");
                if (random.Next(minProzent, maxProzent + 1) > enemyInRoom)
                {
                    Fight(ref taste);
                    if (ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))    //Spielabbruch
                        return;
                }
                else
                {
                    Console.WriteLine("\n\tDu durchquerst den Raum und hattest Glück");
                }

            }
        }

        //Dome
        internal static ConsoleKey YNQuestion()
        {
            Position textPosition = new Position();
            textPosition.Spalte = (uint)Console.CursorLeft;
            ConsoleKey taste = Console.ReadKey().Key;
            while (!ConsoleKeyInfo.Equals(ConsoleKey.Y, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.N, taste) && !ConsoleKeyInfo.Equals(ConsoleKey.Escape, taste))
            {
                Console.CursorLeft = (int)textPosition.Spalte;
                Console.Write(" ");
                Console.CursorLeft = (int)textPosition.Spalte;
                taste = Console.ReadKey().Key;
            }
            Console.WriteLine();
            return taste;
        }

        //Dome
        internal static ConsoleKey KeyQuestion(params ConsoleKey[] permissibleEntrys) //wiederholt eingabe solange bis sie gültig ist
        {
            Position textPosition = new Position();
            textPosition.Spalte = (uint)Console.CursorLeft;
            ConsoleKey taste = Console.ReadKey().Key;
            while (!CheckInput(ref taste,permissibleEntrys))
            {
                Console.CursorLeft = (int)textPosition.Spalte;
                Console.Write(" ");
                Console.CursorLeft = (int)textPosition.Spalte;
                taste = Console.ReadKey().Key;
            }
            Console.WriteLine();
            return taste;
        }

        //Dome
        private static bool CheckInput(ref ConsoleKey taste, ConsoleKey[] permissibleEntrys)    //prüft ob taste zulässig ist
        {
            for (int item = 0; item < permissibleEntrys.Length;item++)
            {
                if (ConsoleKeyInfo.Equals(permissibleEntrys[item] , taste) || ConsoleKeyInfo.Equals(taste , ConsoleKey.Escape))
                {
                    return true;
                }
            }

            return false;
        }

        //Max
        private static void ShowHighscore()
        {
            string[] HighscoreList = Highscore.Reader();
            for (int index = 0; index < 10; index++)
            {
                Console.WriteLine(HighscoreList[index]);
            }
        }

        internal static void EditHighscore()
        {
            string[] HighscoreList = Highscore.Reader();
            int[] TopTenScores = new int[10]; //Werte von platz 1 bis 10
            int index = 0;
            for (; index < 10;index++)
            {
                int scorePointer = HighscoreList[index].Length - 1;
                //scorepointer fängt bei letzter String position von Highscoreplatz(index+1) an bsp Wort "Hallo" scorepointer = 5 (Buchstabe "o")
                //wiederhole solange bis der scorepointer in der zeile auf " " zeigt
                //veringere solange scorepointer
                for (;HighscoreList[index][scorePointer] != '\t';scorePointer--)
                {
                }
                TopTenScores[index] = Convert.ToInt32(HighscoreList[index].Substring(scorePointer+1, HighscoreList[index].Length-1 - scorePointer));
                
            }
            index = 0;
            while(index < 10 && Charakter.Gold < TopTenScores[index])
            {
                index++;
            }
            
            if (Charakter.Gold < TopTenScores[index])
            {   
                //Index zeigt auf 10 und Gold betrag ist kleiner als der von platz 10
                //daher kein Highscoreplatz
                return;
            }

            for (int index2 = 8; index2 > index; index2--)
            {
                //Highscores solange nach unten verschieben bis Index2 Index erreicht
                HighscoreList[index2 + 1] = HighscoreList[index2];
            }

            HighscoreList[index] = (index+1) + "\t" + Charakter.Name + "\t\t" + Charakter.Gold;

            Highscore.Writer(HighscoreList);
            ShowHighscore();

        }

    }
}
