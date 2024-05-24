using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public class Ucastnik : Osoba
    {
        //zde bude odvozená třída pro účastníka řízení
        public string roleVRizeni { get; set; }
        public int unikatniCislo { get; set; } //pro rychlejsi filtrovani?

    }
}
