﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{   
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
        private int health = 10;        // Gegner Hp
        private int maxhealth = 10;     // Maximale Gegner Hp
        private int minhealth = 0;      // Minimale Lebenspunkte
        private string name;            //Gegner Name
        private Weapon Weapon;          //Waffe des Gegners

        //Konstruktor
        Enemy()
        {
            maxhealth = RNGenerator.Next(1, 10);    //Maximalleben wird Zufällig gewählt
            health = maxhealth;                     //Leben entspricht zu beginn immer dem Max Leben
            name = enemyNameModifikator[RNGenerator.Next(0, enemyNameModifikator.Length)] + " " + enemyName[RNGenerator.Next(0, enemyName.Length)];     //Name wird zufällig generiert
            Weapon = new Weapon();                  //Waffe wird Zufällig generiert
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
                if (health + value > maxhealth) health = maxhealth;                 //wenn heilung das Max Leben übersteigen würde
                else if (health + value < minhealth) health = minhealth;            //wenn schaden das Min Leben unterschreiten würde
                else  health += value;                                              //sonst normal lebenspunkte setzen
            }
        }



    }
}
