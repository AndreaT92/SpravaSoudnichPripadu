using SpravaSoudnichPripadu.osoby;

namespace SpravaSoudnichPripadu
{
    // třída pro spravování kolekcí případů - přidat, najít, odebrat a filtrovat 
    // metody pro manipulaci s daty
    public class SpravaPripadu 
    {
        
        private int pocitadloPripadu;
        public List<Pripad> Pripady { get; set; }
        public Dictionary<int, Pripad> PripadDict { get; set; } 

        public SpravaPripadu()
        {
            Pripady = new List<Pripad>();
            PripadDict = new Dictionary<int, Pripad>();
            pocitadloPripadu = 1;
        }

        public void PridatPripad(string popis, List<Ucastnik> ucastnici, Soudce soudce, List<Zastupce> zastupci, DateTime datumJednani, bool jeSkonceno)
        {
            Pripad pripad = new Pripad
            {
                Popis = popis,
                Ucastnici = ucastnici,
                Soudci = soudce,
                Zastupci = zastupci,
                DatumJednani = datumJednani,
                JeSkonceno = jeSkonceno,
            };
            Pripady.Add(pripad);
            PripadDict[pocitadloPripadu] = pripad;
            pocitadloPripadu++;
        }

        public void PridatPreddefinovanePripady()
        {
            var soudce1 = new Soudce
            {
                Jmeno = "Jan",
                Prijmeni = "Novak",
                Adresa = "Praha 1",
                Specializace = Specializace.CivilníPrávo
            };

            var ucastnik1 = new Ucastnik
            {
                Jmeno = "Petr",
                Prijmeni = "Svoboda",
                Adresa = "Brno",
                roleVRizeni = RoleVRizeni.Žalobce
            };

            var ucastnik2 = new Ucastnik
            {
                Jmeno = "Jan",
                Prijmeni = "Malý",
                Adresa = "Praha",
                roleVRizeni = RoleVRizeni.Žalovaný
            };

            var zastupce1 = new Zastupce
            {
                Jmeno = "Oldřich",
                Prijmeni = "Přísný",
                Adresa = "Praha",
                cak = 125125,
                RoleVRizeniZastupce = RoleVRizeniZastupce.ZástupceŽalobce
            };

            var zastupce2 = new Zastupce
            {
                Jmeno = "Jindřich",
                Prijmeni = "Veselý",
                Adresa = "Praha",
                cak = 125128,
                RoleVRizeniZastupce = RoleVRizeniZastupce.ZástupceŽalovaného
            };

            var ucastnici = new List<Ucastnik> { ucastnik1, ucastnik2 };
            var zastupci = new List<Zastupce> { zastupce1, zastupce2 };

            PridatPripad(
                popis: "Případ ve věci náhrady škody za způsobenou dopravní nehodu dne 12. 5. 2024.",
                ucastnici: ucastnici,
                soudce: soudce1,
                zastupci: zastupci,
                datumJednani: new DateTime(2024, 6, 1),
                jeSkonceno: false                
            );
        }

        public Pripad NajitPripadPodleCisla(int cisloPripadu)
        {
            PripadDict.TryGetValue(cisloPripadu, out Pripad pripad);
            return pripad;

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
