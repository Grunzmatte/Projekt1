using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weapons;

namespace Enemys
{   
    //Dome
    /// <summary>
    /// Gegner werden hier generiert und eingestellt
    /// </summary>
    class Enemy
    {
        private static Random RNGenerator = new Random();   //Zufalls Zahlen generator 

        //Namenskombinationen
        private static string[] enemyName = { "Goblin", "Ork", "Oger", "Harpie", "Echsenmensch", "Rattenmensch", "Polizist", "Bademeister", "Oma" };
        private static string[] enemyNameModifikator = { "Alte(r)", "Große(r)", "Grantige(r)", "Junge(r)", "Keifende(r)" };

        //Gegner Werte
        private int health = 0;        // Gegner Hp
        private int maxHealth = 10;     // Maximale Gegner Hp
        private int minHealth = 0;      // Minimale Lebenspunkte
        private string name;            //Gegner Name
        private Weapon weapon;          //Waffe des Gegners

        /// <summary>
        /// Konstruktor
        /// </summary>
        internal Enemy()
        {
            maxHealth = RNGenerator.Next(1, 10);    //Maximalleben wird Zufällig gewählt
            health = maxHealth;                     //Leben entspricht zu beginn immer dem Max Leben
            name = enemyNameModifikator[RNGenerator.Next(0, enemyNameModifikator.Length)] + " " + enemyName[RNGenerator.Next(0, enemyName.Length)];     //Name wird zufällig generiert
            weapon = new Weapon();                  //Waffe wird Zufällig generiert
        }

        /// <summary>
        /// Propertie für Namensabfrage. Namensänderungen sind unzulässig.
        /// </summary>
        internal string Name
        {
            get                                                                     //Name darf nur abgefragt werden
            {
                if (name != null) return name;
                else return "";
            }                  
        }

        /// <summary>
        /// Propertie für Lebens- abfrage und änderung
        /// </summary>
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

        /// <summary>
        /// Propertie für Maxleben- abfrage und änderung
        /// </summary>
        internal int MaxHealth
        {
            get { return maxHealth; }                                               //Maximalen Lebenspunkte abfragen
            set                                                                     //Maximalen Lebenspunkte setzen (bereits implementiert für Buffs / sonstiges?)
            {
                maxHealth = value;                                                 //Maximale Lebenspunkte setzen
            }
        }

        /// <summary>
        /// Propertie für Waffen abfrage
        /// </summary>
        internal Weapon Weapon
        {
            get
            {
                return weapon;
            }
        }
    }
}
