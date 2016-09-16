using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class RoomType
    {
        //Bauplan für Raum Typen
        internal struct Type
        {
            internal string name; //Name des Raumes
            internal int maxAmmountGold; //Maximale Goldmenge in dieser Raumart
        }
        
        //Alle Existierenden Raum Arten
        static private Type kleinen = new Type { name = "kleinen", maxAmmountGold = 5 };
        static private Type mittleren = new Type { name = "mittleren", maxAmmountGold = 10 };
        static private Type großen = new Type { name = "großen", maxAmmountGold = 20 };

        //Array über alle existierenden Raum Arten
        static internal Type[] Names = { kleinen, mittleren, großen };

    }
}
