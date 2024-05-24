using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public class SpravaPripadu
    {
        // Kolekce k ukládání a správě všech případů, účastníků a zástupců?
        public List<Pripad> Pripady { get; set; }
        public Dictionary<int, Pripad> PripadDict { get; set; }

        public SpravaPripadu()
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

        public List<Pripad> FiltrovatPripady(DateTime? datumJednani, bool? jeSkonceno, string soudce, string zastupce)
        {
            var filtrovanePripady = Pripady.AsQueryable();

            if (datumJednani.HasValue)
            {
                filtrovanePripady = filtrovanePripady.Where(p => p.DatumJednani.Date == datumJednani.Value.Date);
            }

            if (jeSkonceno.HasValue)
            {
                filtrovanePripady = filtrovanePripady.Where(p => p.JeSkonceno == jeSkonceno.Value);
            }

            if (!string.IsNullOrEmpty(soudce))
            {
                filtrovanePripady = filtrovanePripady.Where(p => (p.Soudci.Jmeno + " " + p.Soudci.Prijmeni).Contains(soudce));
            }

            if (!string.IsNullOrEmpty(zastupce))
            {
                filtrovanePripady = filtrovanePripady.Where(p => p.Zastupci.Any(z => (z.Jmeno + " " + z.Prijmeni).Contains(zastupce)));
            }

            return filtrovanePripady.ToList();
        }
    }
}
