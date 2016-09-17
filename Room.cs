using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    //Dave + Dome
    class Room
    {
        static private Random RNGenerator = new Random();

        //Raum Daten
        internal RoomType.Type Type;
        
        internal Room()
        {
            Type = SetType();
        }

        private RoomType.Type SetType()
        {
            return RoomType.Names[RNGenerator.Next(0, RoomType.Names.Length)];
        }
                
    }
}
