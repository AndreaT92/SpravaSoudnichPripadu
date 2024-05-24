using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public class Pripad
    {
        public bool JeSkonceno;

        public bool SopZaplacen;
        public int CisloPripadu { get; set; }
        public string Popis { get; set; }
        public List<Ucastnik> Ucastnici { get; set; }
        public Soudce Soudci { get; set; }
        public List<Zastupce> Zastupci { get; set; }
        public DateTime DatumJednani { get; set; }

        public Pripad()
        {
            Ucastnici = new List<Ucastnik>();
            Zastupci = new List<Zastupce>();
        }

        //odvozena třída pro případy? 
        //datum jednání? skončeno? vyplacena odměna? sop?
    }
}
