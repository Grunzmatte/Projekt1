using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weapons
{
    //Dome

    /// <summary>
    /// Object weches den Aufbau der Waffentypen bestimmt
    /// Typnamen , Schadenswerte, Angriffsgeschwindigkeit
    /// </summary>
    class WeaponType
    {
        //Bauplan einer Waffenart
        internal struct Type
        {
            internal string typeName;
            internal int minDamage;
            internal int maxDamage;
            internal int minSpeed;
            internal int maxSpeed;
            internal string nameModifyer;
        }

        //Alle existierenden Waffenarten
        static private Type axt = new Type      { typeName = "Axt",                 minDamage = 3, maxDamage = 5, minSpeed = 3, maxSpeed = 4, nameModifyer = "" };
        static private Type schwert = new Type  { typeName = "Schwert",             minDamage = 2, maxDamage = 4, minSpeed = 2, maxSpeed = 3, nameModifyer = "s" };
        static private Type stein = new Type    { typeName = "Stein",               minDamage = 1, maxDamage = 3, minSpeed = 3, maxSpeed = 5, nameModifyer = "n" };
        static private Type stock = new Type    { typeName = "Stock",               minDamage = 1, maxDamage = 2, minSpeed = 2, maxSpeed = 3, nameModifyer = "n" };
        static private Type fackel = new Type   { typeName = "erloschene Fackel",   minDamage = 1, maxDamage = 2, minSpeed = 2, maxSpeed = 3, nameModifyer = "" };
        static private Type faust = new Type    { typeName = "Faust",               minDamage = 1, maxDamage = 2, minSpeed = 1, maxSpeed = 1, nameModifyer = "" };

        //Array über alle existierenden Waffen
        static internal readonly Type[] type = new Type[] {axt,schwert,stein,stock,fackel,faust};
        
    }
}
