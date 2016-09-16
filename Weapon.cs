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
        static private string[] WeaponNameModifyer = { "alte", "kleine", "große","stumpfe" };
        

        //Waffen Daten
        private WeaponType.Type type;       //Waffentyp
        private string name;                //Name der Waffe
        private int damage;                 //Schaden der Waffe
        private int atackspeed;           //Geschwindigkeit welche bestimmt wer zuerst zuschlägt
        
        internal Weapon()
        {
            type = SetType();           //Waffenart zufällig bestimmen
            damage = SetDamage(type);   //Waffenschaden Zufällig bestimmen
            name = SetName(type);       //Waffennamen Zufällig bestimmen
            atackspeed = SetSpeed(type);//Waffengeschwindigkeit zufällig bestimmen
        }

        internal Weapon(string NameDesCharakters)
        {
            type = WeaponType.type[WeaponType.type.Length];    //Waffentyp bestimmen (Faust des Charakters)
            damage = SetDamage(type);           
            name = NameDesCharakters + "s " + type.typeName;     //Waffennamen Zufällig bestimmen
            atackspeed = SetSpeed(type);
        }

        public int Damage { get { return damage; }  }   //Waffenschaden abfragen

        public string Name { get { return name; } }     //Waffennamen abfragen

        public int Speed { get { return atackspeed; } }     //Waffengeschwindigkeit abfragen
        
        private int SetDamage(WeaponType.Type type)
        {
            int damage;

            //Waffenschaden bestimmen
            damage = RNGenerator.Next(type.minDamage, type.maxDamage + 1);

            return damage; 
        }

        private WeaponType.Type SetType()
        {
            return WeaponType.type[RNGenerator.Next(0, WeaponType.type.Length - 1)];
        }

        private string SetName(WeaponType.Type type)
        {
            return WeaponNameModifyer[RNGenerator.Next(0,WeaponNameModifyer.Length)] + type.nameModifyer + " " + type.typeName;
        }

        private int SetSpeed (WeaponType.Type type)
        {
            return RNGenerator.Next(type.minSpeed,type.maxSpeed+1);
        }
        
    }

    
}
