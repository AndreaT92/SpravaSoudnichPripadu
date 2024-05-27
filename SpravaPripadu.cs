namespace SpravaSoudnichPripadu
{
    public class SpravaPripadu
    {
        // class pro spravování případů - přidat, najít, odebrat, filtrovat 
        public List<Pripad> Pripady { get; set; }
        public Dictionary<int, Pripad> PripadDict { get; set; } // pro lepší hledání přes číslo? 

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

        public Pripad NajitPripadPodleCisla(int cisloPripadu)
        {
            if (!PripadDict.ContainsKey(cisloPripadu)) // možná tohle vyházet, když to řešim v logice filtrování?
            {
                throw new KeyNotFoundException("Případ s tímto číslem neexistuje.");
            }
            return PripadDict[cisloPripadu];
        }

        public void OdebratPripad(int cisloPripadu)
        {
            if (!PripadDict.ContainsKey(cisloPripadu)) // možná tohle vyházet, když to řešim v logice filtrování?
            {
                throw new KeyNotFoundException("Případ s tímto číslem neexistuje.");
            }
            var pripad = PripadDict[cisloPripadu];
            Pripady.Remove(pripad);
            PripadDict.Remove(cisloPripadu);
        }

        public List<Pripad> FiltrovatPripady(DateTime? datumJednani, bool? jeSkonceno, string soudce, string zastupce) // metoda, která vytvoří list vyfiltrovaných případů, nechat tady? Chtělo by to víc ůdajů na vypsání. Dala jsem zkušební část. 
        {
            var filtrovanePripady = Pripady.AsQueryable(); // po googlování by to mělo mělo kolekci převést na IQueryable<Pripad> a 
                                                           // umožnit mi provádět linq dotazy lépe - kdybych chtěla v budoucnu dělat složitější
                                                           // dotazy, ale jestli je to zbytecne, napsala bych var filtrovanePripady = Pripady.ToList();

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
