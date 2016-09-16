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

        static internal string[] Names = { "kleinen", "mittleren", "großen" };

        private string name; //Name des Raumes

        internal Room()
        {
            name = Names[RNGenerator.Next(0, Names.Length)];
        }

        internal string Name
        {
            get { return name; }
        }
         
        
    }
}
