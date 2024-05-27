using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public abstract class SpravaPripaduBase
    {
        public abstract void PridatPripad(Pripad pripad);
        public abstract Pripad NajitPripadPodleCisla(int cisloPripadu);
        public abstract void OdebratPripad(int cisloPripadu);
        public abstract List<Pripad> FiltrovatPripady(DateTime? datumJednani, bool? jeSkonceno, string soudce, string zastupce);
    }
}
