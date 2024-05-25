namespace SpravaSoudnichPripadu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cílem projektu je vytvořit aplikaci pro správu soudních případů,
            //která umožní soudům sledovat a filtrovat jednotlivé případy,
            //účastníky soudních řízení, termíny soudních jednání a časem možná i relevantní dokumenty.



            // výjimky, špatné vstupy - přes try catch? 

            // filtrovani jednani dle různych kriterii (datum, stav, soudce...) ?

            // umožnit zadávat nové případy přes vstup uživatele? 

            var spravaPripadu = new SpravaPripadu();

            try
            {
                var soudce1 = new Soudce
                {
                    Jmeno = "Jan",
                    Prijmeni = "Novak",
                    Adresa = "Praha 1",
                    Specializace = "Civilní právo"
                };

                var ucastnik1 = new Ucastnik
                {
                    Jmeno = "Petr",
                    Prijmeni = "Svoboda",
                    Adresa = "Brno",
                    unikatniCislo = 101,
                    roleVRizeni = "žalobce"
                };

                var ucastnik2 = new Ucastnik
                {
                    Jmeno = "Jan",
                    Prijmeni = "Malý",
                    Adresa = "Praha",
                    unikatniCislo = 102,
                    roleVRizeni = "žalovaný"
                };

                var zastupce1 = new Zastupce
                {
                    Jmeno = "Oldřich",
                    Prijmeni = "Přísný",
                    Adresa = "Praha",
                    CisloCak = 125125
                };

                var pripad = new Pripad
                {
                    CisloPripadu = 1,
                    Popis = "Případ ve věci náhrady škody za způsobenou dopravní nehodu dne 12. 5. 2024.",
                    DatumJednani = new DateTime(2024, 6, 1),
                    Soudci = soudce1,
                    JeSkonceno = false,
                    SopZaplacen = false,
                    JeOdmenaZaplacena = false,
                };

                pripad.Ucastnici.Add(ucastnik1);
                pripad.Ucastnici.Add(ucastnik2);
                pripad.Zastupci.Add(zastupce1);

                spravaPripadu.PridatPripad(pripad);

                var logikaFiltrovani = new LogikaFiltrovani(spravaPripadu);
                logikaFiltrovani.Spustit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Došlo k chybě: {ex.Message}");
            }

        }
    }
}
