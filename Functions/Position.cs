using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Position
    {
        uint zeile;
        uint spalte;

        public uint Zeile { get { return zeile; } set { zeile = value; } }
        public uint Spalte { get { return spalte; } set { spalte = value; } }

    }
}
