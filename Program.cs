namespace SpravaSoudnichPripadu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cílem projektu je vytvořit aplikaci pro správu soudních případů,
            //která umožní soudům efektivně řídit a sledovat jednotlivé případy,
            //účastníky soudních řízení, termíny soudních jednání a časem možná i relevantní dokumenty.
            //Aplikace by měla poskytovat přehledné rozhraní pro správu těchto informací
            //a zajišťovat snadný přístup ke všem potřebným datům.

            // kolekce k ukládání a správě všech případů, účastníků a zástupců?

            // výjimky, špatné vstupy - neplatne jmeno? 

            // filtrovani jednani dle různych kriterii (datum, stav, soudce...)

            var spravaPripadu = new Sprava();

            try
            {
                var soudce = new Soudce
                {
                    Jmeno = "Jan",
                    Prijmeni = "Novak",
                    Adresa = "Praha 1",
                    Specializace = "Trestní právo"
                };

                var ucastnik1 = new Ucastnik
                {
                    Jmeno = "Petr",
                    Prijmeni = "Svoboda",
                    Adresa = "Brno",
                };

                var pripad = new Pripad
                {
                    CisloPripadu = 1,
                    Popis = "Trestní případ",
                    DatumJednani = new DateTime(2024, 6, 1),
                    Soudci = soudce
                };
                pripad.Ucastnici.Add(ucastnik1);

                spravaPripadu.PridatPripad(pripad);

                var nalezenyPripad = spravaPripadu.NajitPripad(1);
                Console.WriteLine($"Nalezený případ: {nalezenyPripad.Popis}");

                spravaPripadu.OdebratPripad(1);
                Console.WriteLine("Případ byl úspěšně odstraněn.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Došlo k chybě: {ex.Message}");
            }

        }
    }
}
