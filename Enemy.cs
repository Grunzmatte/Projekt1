using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{   
    //Dome
    /// <summary>
    /// Gegner werden hier eingestellt
    /// </summary>
    class Enemy
    {
        private static Random RNGenerator = new Random();   //Zufalls Zahlen generator 

        //Namenskombinationen
        private static string[] enemyName = { "Goblin", "Ork", "Oger", "Harpie", "Schlange", "Ratte", "Polizist", "Bademeister", "Oma" };
        private static string[] enemyNameModifikator = { "Alte(r)", "Große(r)", "Grantige(r)", "Junge(r)", "Keifende(r)" };

        //Gegner Werte
        private int health = 0;        // Gegner Hp
        private int maxHealth = 10;     // Maximale Gegner Hp
        private int minHealth = 0;      // Minimale Lebenspunkte
        private string name;            //Gegner Name
        private Weapon weapon;          //Waffe des Gegners

        //Konstruktor
        internal Enemy()
        {
            maxHealth = RNGenerator.Next(1, 10);    //Maximalleben wird Zufällig gewählt
            health = maxHealth;                     //Leben entspricht zu beginn immer dem Max Leben
            name = enemyNameModifikator[RNGenerator.Next(0, enemyNameModifikator.Length)] + " " + enemyName[RNGenerator.Next(0, enemyName.Length)];     //Name wird zufällig generiert
            weapon = new Weapon();                  //Waffe wird Zufällig generiert
        }

        internal string Name
        {
            get                                                                     //Name darf nur abgefragt werden
            {
                if (name != null) return name;
                else return "";
            }                  
        }

        internal int Health
        {
            get { return health; }                                                  //Lebenspunkte abfragen
            set                                                                     //Lebenspunkte setzen
            {
                if ( value > maxHealth) health = maxHealth;                 //wenn heilung das Max Leben übersteigen würde
                else if ( value < minHealth) health = minHealth;            //wenn schaden das Min Leben unterschreiten würde
                else  health = value;                                              //sonst normal lebenspunkte setzen
            }
        }

        internal int MaxHealth
        {
            get { return maxHealth; }                                               //Maximalen Lebenspunkte abfragen
            set                                                                     //Maximalen Lebenspunkte setzen (bereits implementiert für Buffs / sonstiges?)
            {
                maxHealth = value;                                                 //Maximale Lebenspunkte setzen
            }
        }

        internal Weapon Weapon
        {
            get
            {
                return weapon;
            }

        }
    }
}
