using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public class Sprava
    {
        public List<Pripad> Pripady { get; set; }
        public Dictionary<int, Pripad> PripadDict { get; set; }

        public Sprava()
        {
            Pripady = new List<Pripad>();
            PripadDict = new Dictionary<int, Pripad>();
        }

        public void PridatPripad(Pripad pripad)
        {
            if (PripadDict.ContainsKey(pripad.CisloPripadu))
            {
                throw new ArgumentException("Případ s tímto číslem již existuje.");
            }
            Pripady.Add(pripad);
            PripadDict[pripad.CisloPripadu] = pripad;
        }

        public Pripad NajitPripad(int cisloPripadu)
        {
            if (!PripadDict.ContainsKey(cisloPripadu))
            {
                throw new KeyNotFoundException("Případ s tímto číslem neexistuje.");
            }
            return PripadDict[cisloPripadu];
        }

        public void OdebratPripad(int cisloPripadu)
        {
            if (!PripadDict.ContainsKey(cisloPripadu))
            {
                throw new KeyNotFoundException("Případ s tímto číslem neexistuje.");
            }
            var pripad = PripadDict[cisloPripadu];
            Pripady.Remove(pripad);
            PripadDict.Remove(cisloPripadu);
        }
    }
}
