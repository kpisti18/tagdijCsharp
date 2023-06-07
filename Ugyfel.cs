using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kovacs_Istvan_01_console
{
    internal class Ugyfel
    {
        public int Azon { get; set; }
        public string Nev { get; set; }
        public int Szulev { get; set; }
        public string Irszam { get; set; }
        public string Orsz { get; set; }

        public Ugyfel(int azon, string nev, int szulev, string irszam, string orsz)
        {
            Azon = azon;
            Nev = nev;
            Szulev = szulev;
            Irszam = irszam;
            Orsz = orsz;
        }

        public override string ToString()
        {
            return $"{Nev}";
        }
    }
}
