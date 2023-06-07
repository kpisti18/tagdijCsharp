using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kovacs_Istvan_01_console
{
    internal class Befizetes
    {
        public int Azon { get; set; }
        public DateTime Datum { get; set; }
        public int Osszeg { get; set; }

        public Befizetes(int azon, DateTime datum, int osszeg)
        {
            Azon = azon;
            Datum = datum;
            Osszeg = osszeg;
        }

        public override string ToString()
        {
            return $"{Datum}:\t{Osszeg} Ft";
        }
    }
}
