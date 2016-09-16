using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class Room
    {
        static private Random RNGenerator = new Random();

        static internal string[] roomName = { "kleiner", "mittlerer", "großer" };

        static internal string name; //Name des Raumes
         
        internal static string prefix()
        {
            return name = roomName[RNGenerator.Next(0, roomName.Length)];
        }
    }
}
