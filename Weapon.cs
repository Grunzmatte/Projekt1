using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    //Dome
    class Weapon
    {
        static private Random RNGenerator = new Random();       //Zufalls Zahlen Generator

        //Namenskombinationen
        static private string[] Weapons = { "Axt", "Schwert", "Stein", "Stock", "erloschene Fackel" };
        static private string[] WeaponNameModifyer = { "alte(r/s)", "kleine(r/s)", "große(r/s)","stumpfe(r/s)" };
        
        //Waffenschadenswerte

        //Waffen Daten
        private string type;        //Waffentyp
        private string name;        //Name der Waffe
        private int damage;         //Schaden der Waffe
        static private int minWeaponDamage = 1;     //Mindestschaden den eine Waffe machen muss
        static private int maxWeaponDamage = 5;     //Maximalschaden den eine Waffe machen kann

        internal Weapon()
        {
            type = Weapons[RNGenerator.Next(0, Weapons.Length)];    //Waffentyp bestimmen
            damage = RNGenerator.Next(minWeaponDamage, maxWeaponDamage + 1);            //Waffenschaden Zufällig bestimmen
            name = WeaponNameModifyer[RNGenerator.Next(0, WeaponNameModifyer.Length)] + " " + type;     //Waffennamen Zufällig bestimmen
        }

        internal Weapon(string NameDesCharakters)
        {
            type = "Faust";    //Waffentyp bestimmen (Faust des Charakters)
            damage = 1;            //Waffenschaden auf 1 setzen
            name = NameDesCharakters + "Faust"  ;     //Waffennamen Zufällig bestimmen
        }



        public int Damage { get { return damage; }  }   //Waffenschaden abfragen

        public string Name { get { return name; } }     //Waffennamen abfragen
        
    }

    
}
