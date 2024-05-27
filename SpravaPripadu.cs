namespace SpravaSoudnichPripadu
{
    public class SpravaPripadu 
    {
        // class pro spravování kolekcí případů - přidat, najít, odebrat, filtrovat 
        // metody pro manipulaci s daty
        private int pocitadloPripadu;
        public List<Pripad> Pripady { get; set; }
        public Dictionary<int, Pripad> PripadDict { get; set; } // pro lepší hledání přes číslo? 

        public SpravaPripadu()
        {
            Pripady = new List<Pripad>();
            PripadDict = new Dictionary<int, Pripad>();
            pocitadloPripadu = 0;
        }

        public void PridatPripad(DateTime datumJednani) // přidat ostatní parametry !!!
        {
            Pripad pripad = new Pripad
            {
                DatumJednani = datumJednani,
                CisloPripadu = ++pocitadloPripadu
            };

            Pripady.Add(pripad);
            PripadDict[pripad.CisloPripadu] = pripad;
        }

        public Pripad NajitPripadPodleCisla(int cisloPripadu)
        {
            PripadDict.TryGetValue(cisloPripadu, out Pripad pripad);
            return pripad;
            // možná tohle vyházet, když to řešim v logice filtrování?

        }

        public bool OdebratPripad(int cisloPripadu)
        {
            bool povedloSe = PripadDict.TryGetValue(cisloPripadu, out Pripad pripad);
            if (povedloSe) 
            { 
                Pripady.Remove(pripad);
                PripadDict.Remove(cisloPripadu);
            }
            return povedloSe;
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
